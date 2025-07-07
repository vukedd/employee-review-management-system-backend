using Application.Common.Repositories;
using Domain.Models.Memberships;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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

        public async Task<IEnumerable<Domain.Models.Memberships.Team>> GetTeamsByUsername(string username)
        {
            return await _context.Teams.Where(t => t.Memberships.Any(m => m.User.Username == username)).ToListAsync();
        }

        public async Task<Domain.Models.Memberships.Team?> GetTeamById(long teamId)
        {
            return await _context.Teams.Where(t => t.Id == teamId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetTeammatesByUsername(string username)
        {
            HashSet<string> users = new HashSet<string>();

            List<Domain.Models.Memberships.Membership> userMemberships = await _context.Memberships.Where(m => m.User.Username == username).Include("User").ToListAsync();
            List<Domain.Models.Memberships.Team> teams = new List<Domain.Models.Memberships.Team>();
            foreach (var membership in userMemberships)
            {
                Domain.Models.Memberships.Team currTeam = await _context.Teams.Where(t => t.Id == membership.TeamId).FirstOrDefaultAsync();
                
                if (currTeam != null)
                    teams.Add(currTeam);
            }

            List<Domain.Models.Memberships.Membership> collegueMemberships = new List<Domain.Models.Memberships.Membership>();

            foreach (var team in teams)
            {
                var teamMemberships = await _context.Memberships.Where(m => m.TeamId == team.Id).Include("User").ToListAsync();
                foreach (var membership in teamMemberships)
                {
                    var currUser = membership.User.Username;
                    if (currUser != username)
                        users.Add(currUser);

                    Trace.WriteLine(currUser);
                }
            }

            return users;
        }
    }
}
