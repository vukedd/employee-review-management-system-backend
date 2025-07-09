using Presentation.Contracts.Request.Membership;

namespace Presentation.Contracts.Request.Team
{
    public class EditTeamContract
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CreateMembershipContract> Memberships { get; set; } = new List<CreateMembershipContract>();
    }
}
