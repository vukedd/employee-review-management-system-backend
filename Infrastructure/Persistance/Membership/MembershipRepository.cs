using Application.Common.Repositories;
using Domain.Models.Memberships;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Membership
{   
    public class MembershipRepository : IMembershipRepository
    {
        private readonly AppDbContext _context;
        public MembershipRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> GetMembershipsByTeamId(long teamId)
        {
            return await _context.Memberships.Where(m => m.TeamId == teamId).Include("User").ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> GetMembershipsByUserIdAsync(long userId)
        {
            return await _context.Memberships.Where(m => m.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> GetMembershipsByUsernameAsync(string username)
        {
            return await _context.Memberships.Where(m => m.User.Username == username).Include("Team").ToListAsync();
        }


        public async Task<Domain.Models.Memberships.Membership?> DeleteMembershipById(long membershipid)
        {
            var membership = await _context.Memberships.Where(m => m.Id == membershipid).FirstOrDefaultAsync();
            if (membership != null)
            {
                _context.Remove(membership);
                await _context.SaveChangesAsync();
            }
            return membership;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> GetTeammatesByTeamId(long teamId)
        {
            return await _context.Memberships.Include("User").Where(m => m.TeamId == teamId).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> GetAllMemberships()
        {
            return await _context.Memberships.Include("User").ToListAsync();
        }
    }
}
