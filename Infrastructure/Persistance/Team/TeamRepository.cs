using Application.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Team
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;
        public TeamRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Domain.Models.Memberships.Team> CreateTeamAsync(Domain.Models.Memberships.Team team)
        {
            var addedTeam = await _context.AddAsync(team);
            await _context.SaveChangesAsync();

            return addedTeam.Entity;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Team>> GetAllTeams()
        {
            var teams = await _context.Teams.Include("Memberships.User").ToListAsync();
            return teams;
        }

        public async Task<Domain.Models.Memberships.Team?> GetTeamByName(string name)
        {
            return await _context.Teams.Where(t => t.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Team>> GetTeamsByUserId(long userId)
        {
            return await _context.Teams.Where(t => t.Memberships.Any(m => m.UserId == userId)).ToListAsync();
        }
    }
}
