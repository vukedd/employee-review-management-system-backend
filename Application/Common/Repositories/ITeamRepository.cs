using Domain.Models.Memberships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface ITeamRepository
    {
        public Task<Domain.Models.Memberships.Team> CreateTeamAsync(Team team);
        public Task<Domain.Models.Memberships.Team?> GetTeamByName(string name);
        public Task<IEnumerable<Domain.Models.Memberships.Team>> GetAllTeams();
        public Task<IEnumerable<Domain.Models.Memberships.Team>> GetTeamsByUsername(string username);
        public Task<Domain.Models.Memberships.Team?> GetTeamById(long teamId);
        public Task<IEnumerable<string>> GetTeammatesByUsername(string username);
        public Task<Domain.Models.Memberships.Team?> EditTeam(long id, Team team);
    }
}
