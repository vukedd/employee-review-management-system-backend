using Application.Commands.Team;
using Presentation.Contracts.Request.Team;
using Presentation.Contracts.Response.Team;
using Presentation.Mappers.Membership;

namespace Presentation.Mappers.Team
{
    public static class TeamMapper
    {
        public static CreateTeamCommand ToCreateCommand(this CreateTeamContract contract)
            => new CreateTeamCommand(contract.Name, contract.Memberships.Select(m => m.ToMembershipDto()).ToList());

        public static CreateTeamResponse ToCreateResponse(this Domain.Models.Memberships.Team team)
        {
            return new CreateTeamResponse
            {
                Name = team.Name,
                Memberships = team.Memberships.Select(m => m.ToCreateMembershipResponse()).ToList()
            };
        }
    }
}
