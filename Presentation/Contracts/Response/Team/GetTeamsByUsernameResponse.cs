namespace Presentation.Contracts.Response.Team
{
    public class GetTeamsByUsernameResponse
    {
        IEnumerable<CreateTeamResponse> Teams { get; set; }
    }
}
