using Application.Common.Repositories;
using Domain.Enums.User;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
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

        public async Task<Role?> GetRoleByUserId(long id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null)
                return null;

            return user.Role;
        }

        public async Task<Domain.Models.Users.User?> GetUserByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Domain.Models.Users.User?> GetUserByUsername(string username)
        {
            return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<Domain.Models.Users.User?> GetUserById(long id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Domain.Models.Users.User>> GetAllUsers()
        {
            return await _context.Users.Where(u => u.Role != Role.MANAGER).ToListAsync();
        }

        public async Task<Domain.Models.Users.User?> GetUserByVerificationToken(string token)
        {
            return await _context.Users.Where(u => u.VerificationToken == token).FirstOrDefaultAsync();
        }

        public async Task VerifyUser(long id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.Verified = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
