namespace Presentation.Contracts.Response.Membership
{
    public class CreateMembershipResponse
    {
        public long UserId { get; set; }
        public bool IsTeamLead { get; set; }
    }
}
