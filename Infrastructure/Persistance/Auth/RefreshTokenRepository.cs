using Application.Common.Repositories;
using Domain.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Auth
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;
        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> CreateNewRefreshTokenAsync(long userId)
        {
            var token = new RefreshToken
            {
                ExpiryDate = DateTime.Now.AddDays(7),
                Token = GenerateRefreshToken(),
                IsRevoked = false,
                UserId = userId
            };

            var addedToken = await _context.RefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();

            return addedToken.Entity;
        }

        public async Task<RefreshToken> RevokeRefreshTokenAsync(string token)
        {
            var rt = await _context.RefreshTokens.Where(rt => rt.Token == token).FirstOrDefaultAsync();

            if (token != null)
            {
                rt.IsRevoked = true;
                await _context.SaveChangesAsync();
            }

            return rt;
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            var rToken = await _context.RefreshTokens.Where(t => t.Token == token).Include("User").FirstOrDefaultAsync();
            return rToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }
    }
}
