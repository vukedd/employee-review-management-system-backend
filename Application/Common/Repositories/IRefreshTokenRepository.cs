using Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IRefreshTokenRepository
    {
        public Task<RefreshToken> CreateNewRefreshTokenAsync(long userId);
        public Task<RefreshToken> RevokeRefreshTokenAsync(string token);
        public Task<RefreshToken> GetByTokenAsync(string token);
    }
}
