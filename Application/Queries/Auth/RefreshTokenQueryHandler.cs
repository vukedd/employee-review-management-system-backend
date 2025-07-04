using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Common.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Auth
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, string>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtService _jwtService;
        public RefreshTokenQueryHandler(IJwtService jwtService, IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.token);
            if (refreshToken == null)
                throw new UnauthorizedException("");

            if (refreshToken.IsRevoked || refreshToken.ExpiryDate < DateTime.Now)
            {
                refreshToken.IsRevoked = true;
                var revokedToken = _refreshTokenRepository.RevokeRefreshTokenAsync(request.token);
                throw new UnauthorizedException("");
            }

            var newAccessToken = await _jwtService.GenerateTokensAsync(refreshToken.User.Username, refreshToken.User.Role.ToString());
            return newAccessToken.AccessToken;   
        }
    }

    public record RefreshTokenQuery(string token) : IRequest<string>;
}
