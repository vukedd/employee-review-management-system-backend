using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Memberships
{
    public class Membership
    {   
        public long Id { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }

        public long TeamId { get; set; }
        public Team? Team { get; set; }

        public bool IsTeamLead { get; set; }
    }
}
