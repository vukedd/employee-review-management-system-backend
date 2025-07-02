using Application.Common.Repositories;
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

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> GetMembershipsByUserIdAsync(long userId)
        {
            return await _context.Memberships.Where(m => m.UserId == userId).ToListAsync();
        }
    }
}
