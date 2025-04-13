using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.System;
using Shared.Commands;

namespace Application.Auth.Commands
{
    public record RegisterCommand(string Email, string Password) : ICommand<AuthResponse> { }

    // public class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthResponse>
    // {
    //     private readonly IUserRepository _userRepo;
    //     private readonly IJwtTokenGenerator _jwtGen;

    //     public RegisterCommandHandler(IUserRepository userRepo, IJwtTokenGenerator jwtGen)
    //     {
    //         _userRepo = userRepo;
    //         _jwtGen = jwtGen;
    //     }

    //public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken ct)
    //{
    //    //if (await _userRepo.ExistsByEmailAsync(request.Email))
    //    //    throw new Exception("Email already exists");

    //    //var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
    //    //var user = new UserEntity
    //    //{
    //    //    id = Guid.NewGuid().ToString(),
    //    //    Email = request.Email,
    //    //    PasswordHash = passwordHash,
    //    //};

    //    //await _userRepo.AddAsync(user);
    //    //var token = _jwtGen.GenerateToken(user);

    //    //return new AuthResponse(user.Email, token);
    //}
    // }
}
