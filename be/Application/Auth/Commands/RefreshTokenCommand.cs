using System.Security.Claims;
using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.System;
using Domain.Entities.System;
using Shared.Commands;
using Shared.Exceptions;

namespace Application.Auth.Commands
{
    public record RefreshTokenCommand(string RefreshToken) : ICommand<RefreshTokenResponse> { }

    public class RefreshTokenCommandHandler
        : ICommandHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        private readonly IJwtTokenGenerator _jwtGen;
        private readonly IKeyTokenRepository _key;
        private readonly IUserRepository _rep;

        public RefreshTokenCommandHandler(
            IJwtTokenGenerator jwtGen,
            IUserRepository rep,
            IKeyTokenRepository key
        )
        {
            _jwtGen = jwtGen;
            _key = key;
            _rep = rep;
        }

        public async Task<RefreshTokenResponse> Handle(
            RefreshTokenCommand request,
            CancellationToken cancellationToken
        )
        {
            var principal = _jwtGen.ValidateRefreshToken(request.RefreshToken);
            if (principal == null)
            {
                throw new BadRequestException("Invalid refresh token");
            }

            var userId = principal.FindFirstValue("id");

            // Check nếu đã tồn tại refresh token
            var oldToken = await _key.GetAsync(request.RefreshToken);
            if (oldToken == null)
                throw new NotFoundException("Refresh token not found");

            var user = await _rep.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            // Tạo refresh token mới
            var newAccessToken = _jwtGen.GenerateToken(user.id, user.email, user.role.ToString());
            var newRefreshToken = _jwtGen.GenerateRefreshToken(user.id);

            KeyTokenEntity updated = new()
            {
                token = newRefreshToken,
                updated_at = DateTime.UtcNow.Ticks,
            };

            await _key.UpdateAsync(oldToken.id, updated);

            return new RefreshTokenResponse(newAccessToken, newRefreshToken);
        }
    }
}
