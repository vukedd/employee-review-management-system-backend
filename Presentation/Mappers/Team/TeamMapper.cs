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
                Id = team.Id,
                Name = team.Name,
                Memberships = team.Memberships.Select(m => m.ToCreateMembershipResponse()).ToList()
            };
        }

        public static GetTeamByIdResponse ToGetByIdResponse(this Domain.Models.Memberships.Team team)
        {
            return new GetTeamByIdResponse
            {
                Id = team.Id,
                Name = team.Name
            };
        }

        public static TeamDisplayDto ToDisplayDto(this Domain.Models.Memberships.Team team)
        {
            return new TeamDisplayDto
            {
                Name = team.Name,
                Id = team.Id,
                LeadName = team.Memberships.Where(m => m.IsTeamLead).Select(m => m.User.Username).FirstOrDefault()
            };
        }

        public static EditTeamResponse ToEditResponse(this Domain.Models.Memberships.Team team)
        {
            return new EditTeamResponse
            {
                Name = team.Name,
                Memberships = team.Memberships.Select(m => m.ToCreateMembershipResponse()).ToList()
            };
        }
    }
}
