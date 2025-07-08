namespace Presentation.Contracts.Response.Team
{
    public class TeamHierarchyResponse
    {
        public string Label { get; set; }
        public List<TeamHierarchyResponse> Children { get; set; } = new List<TeamHierarchyResponse>();

        public TeamHierarchyResponse(string Name)
        {
            this.Label = Name;
        }
        public TeamHierarchyResponse()
        {
            
        }
    }
}
