using Application.Common.DTOs;
using Presentation.Contracts.Request.Membership;
using Presentation.Contracts.Response.Membership;
using Presentation.Contracts.Response.Team;
using Presentation.Endpoints.Evaluation;
using Presentation.Endpoints.Membership;
using System.Linq.Expressions;

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

        public static TeamHierarchyResponse ToTeamHieararchyResponse(this IEnumerable<Domain.Models.Memberships.Membership> memberships)
        {
            TeamHierarchyResponse teamHieararchyResponse = new TeamHierarchyResponse();
            HashSet<string> seen = new HashSet<string>();

            var teamLead = memberships.Where(m => m.IsTeamLead == true).First();
            seen.Add(teamLead.User.Username);
            teamHieararchyResponse.Label = teamLead.User.Username;

            foreach (var membership in memberships)
            {
                if (!seen.Contains(membership.User.Username)) {
                    teamHieararchyResponse.Children.Add(new TeamHierarchyResponse(membership.User.Username));
                }
            }

            return teamHieararchyResponse;
        }
    }
}
