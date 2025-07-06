using Application.Common.DTOs;
using Presentation.Contracts.Request.Membership;
using Presentation.Contracts.Response.Membership;
using Presentation.Endpoints.Evaluation;
using Presentation.Endpoints.Membership;

namespace Presentation.Mappers.Membership
{
    public static class MembershipMapper
    {
        public static MembershipDto ToMembershipDto(this CreateMembershipContract contract)
        {
            return new MembershipDto
            {
                UserId = contract.UserId,
                IsTeamLead = contract.IsTeamLead,
            };
        }

        public static CreateMembershipResponse ToCreateMembershipResponse(this Domain.Models.Memberships.Membership membership)
        {
            return new CreateMembershipResponse
            {
                UserId = membership.UserId,
                IsTeamLead = membership.IsTeamLead,
            };
        }

        public static GetMembershipByUsernameResponse ToGetByUsernameResponse(this Domain.Models.Memberships.Membership membership)
        {
            return new GetMembershipByUsernameResponse
            {
                TeamId = membership.TeamId,
                IsTeamLead = membership.IsTeamLead,
                Name = membership.Team.Name
            };
        }
    }
}
