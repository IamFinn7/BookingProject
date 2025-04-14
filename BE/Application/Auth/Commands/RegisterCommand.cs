using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.System;
using Domain.Entities;
using FluentValidation;
using Shared.Commands;
using Shared.Helpers;

namespace Application.Auth.Commands
{
    public record RegisterCommand(string Email, string Password) : ICommand<AuthResponse> { }

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }

    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthResponse>
    {
        private readonly IUserRepository _rep;
        private readonly IJwtTokenGenerator _jwtGen;

        public RegisterCommandHandler(IUserRepository rep, IJwtTokenGenerator jwtGen)
        {
            _rep = rep;
            _jwtGen = jwtGen;
        }

        public async Task<AuthResponse> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            var existingUser = await _rep.GetByEmailAsync(request.Email);
            if (existingUser is not null)
                throw new Exception("Email is already registered.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new UserEntity
            {
                id = SystemHelper.RandomId(),
                email = request.Email,
                password = passwordHash,
                role = Role.Customer,
            };

            await _rep.RegisterAccountAsync(newUser);

            var token = _jwtGen.GenerateToken(
                newUser.id.ToString(),
                newUser.email,
                newUser.role.ToString()
            );

            return new AuthResponse(newUser.id, newUser.email, token);
        }
    }
}
