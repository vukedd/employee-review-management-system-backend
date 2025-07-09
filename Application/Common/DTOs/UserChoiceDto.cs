using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public class UserChoiceAppDto
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public bool IsTeamLead { get; set; }
    }
}
