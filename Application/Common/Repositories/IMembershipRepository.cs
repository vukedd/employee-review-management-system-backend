using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IMembershipRepository
    {
        public Task<IEnumerable<Domain.Models.Memberships.Membership>> GetMembershipsByUserIdAsync(long userId);
        public Task<IEnumerable<Domain.Models.Memberships.Membership>> GetMembershipsByUsernameAsync(string username);
        public Task<IEnumerable<Domain.Models.Memberships.Membership>> GetMembershipsByTeamId(long teamId);
        public Task<Domain.Models.Memberships.Membership?> DeleteMembershipById(long membershipid);
        public Task<IEnumerable<Domain.Models.Memberships.Membership>> GetTeammatesByTeamId(long teamId);
        public Task<IEnumerable<Domain.Models.Memberships.Membership>> GetAllMemberships();

    }
}
