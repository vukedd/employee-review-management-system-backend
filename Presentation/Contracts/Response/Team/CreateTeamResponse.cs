using Presentation.Contracts.Response.Membership;

namespace Presentation.Contracts.Response.Team
{
    public class CreateTeamResponse
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CreateMembershipResponse> Memberships { get; set; } = new List<CreateMembershipResponse>();

    }
}
