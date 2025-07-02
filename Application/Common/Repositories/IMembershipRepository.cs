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
    }
}
