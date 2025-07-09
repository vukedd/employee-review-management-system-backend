using Application.Commands.Team;
using Application.Mappers.Membership;
using Domain.Models.Memberships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Team
{
    public static class TeamMapper
    {
        public static Domain.Models.Memberships.Team ToDomainEntity(this CreateTeamCommand command)
        {
            return new Domain.Models.Memberships.Team
            {
                Name = command.Name,
                Memberships = command.Memberships.Select(m => m.ToDomainEntity()).ToList(),
            };
        }
        public static Domain.Models.Memberships.Team ToDomain2Entity(this EditTeamCommand command)
        {
            return new Domain.Models.Memberships.Team
            {
                Name = command.Name,
                Memberships = command.Memberships.Select(m => m.ToDomainEntity()).ToList(),
            };
        }
    }
}
