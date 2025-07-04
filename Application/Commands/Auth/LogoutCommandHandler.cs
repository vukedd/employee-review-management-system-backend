using Application.Common.Exceptions;
using Application.Common.Repositories;
using Domain.Models.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Auth
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, RefreshToken>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public LogoutCommandHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.token);

            if (refreshToken == null)
                throw new ForbiddenException("");

            if (refreshToken.ExpiryDate < DateTime.Now || refreshToken.IsRevoked)
                throw new ForbiddenException("");

            var revokedToken = await _refreshTokenRepository.RevokeRefreshTokenAsync(request.token);
            return revokedToken;
        }
    }

    public record LogoutCommand(string token) : IRequest<RefreshToken> { };
}
