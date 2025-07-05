namespace Presentation.Contracts.Response.Team
{
    public class GetTeamsByUserIdResponse
    {
        IEnumerable<CreateTeamResponse> Teams { get; set; }
    }
}
