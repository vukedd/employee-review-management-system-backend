using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Team
    {
        public long Id { get; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public User? TeamLead { get; set; }
        public long TeamLeadId { get; set; }

        public Team(string name, List<User> members, long teamLeadId)
        {
            this.Name = name;
            this.Members = members;
            this.TeamLeadId = teamLeadId;
        }
    }
}
