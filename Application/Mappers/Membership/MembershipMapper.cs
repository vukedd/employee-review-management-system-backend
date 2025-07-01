using Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Membership
{
    public static class MembershipMapper
    {
        public static Domain.Models.Memberships.Membership ToDomainEntity(this MembershipDto membershipDto)
        {
            return new Domain.Models.Memberships.Membership
            {
                IsTeamLead = membershipDto.IsTeamLead,
                UserId = membershipDto.UserId,
            };
        }
    }
}
