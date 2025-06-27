using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Memberships
{
    public class Team
    {
        public long Id { get;}
        public string Name { get; set; }
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();


        public Team(string name)
        {
            Name = name;
        }
    }
}
