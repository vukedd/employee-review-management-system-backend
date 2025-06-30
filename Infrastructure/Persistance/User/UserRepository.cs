using Application.Common.Repositories;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Users.User> CreateAsync(Domain.Models.Users.User user)
        {
            var addedUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return addedUser.Entity;
        }

        public async Task<Domain.Models.Users.User?> GetUserByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Domain.Models.Users.User?> GetUserByUsername(string username)
        {
            return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}
