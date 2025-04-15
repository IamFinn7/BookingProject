using Application.Auth.Exceptions;
using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.System;
using Domain.Entities.System;
using FluentValidation;
using Shared.Commands;
using Shared.Helpers;

namespace Application.Auth.Commands
{
    public record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;

    public class LoginCommandCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }

    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _rep;
        private readonly IJwtTokenGenerator _jwtGen;
        private readonly IKeyTokenRepository _key;

        public LoginCommandHandler(
            IUserRepository rep,
            IJwtTokenGenerator jwtGen,
            IKeyTokenRepository key
        )
        {
            _rep = rep;
            _jwtGen = jwtGen;
            _key = key;
        }

        public async Task<LoginResponse> Handle(
            LoginCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _rep.GetByEmailAsync(request.Email.ToLower());

            if (user == null)
                throw new AuthNotFoundException(request.Email);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.password))
            {
                throw new InvalidAuthCredentialsException();
            }

            var role = user.role.ToString();

            var accessToken = _jwtGen.GenerateToken(user.id, user.email, role);
            var refreshToken = _jwtGen.GenerateRefreshToken(user.id);

            await _key.SaveAsync(
                new KeyTokenEntity
                {
                    id = SystemHelper.RandomId(),
                    token = refreshToken,
                    user_id = user.id,
                    created_at = DateTime.UtcNow.Ticks,
                }
            );

            return new LoginResponse
            {
                User = new LoginResponse.UserLoginResponse { UserId = user.id },
                Tokens = new LoginResponse.Token
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                },
            };
        }
    }
}
