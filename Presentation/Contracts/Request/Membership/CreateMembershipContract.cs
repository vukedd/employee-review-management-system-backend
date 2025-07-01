namespace Presentation.Contracts.Request.Membership
{
    public class CreateMembershipContract
    {
        public long UserId { get; set; }
        public bool IsTeamLead { get; set; }
    }
}
