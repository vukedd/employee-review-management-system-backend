namespace Presentation.Contracts.Response.Membership
{
    public class GetMembershipByUsernameResponse
    {
        public long TeamId { get; set; }
        public bool IsTeamLead { get; set; }
        public string Name { get; set;}
    }
}
