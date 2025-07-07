namespace Presentation.Contracts.Request.Feedback
{
    public class GetLatestFeedbackRequest
    {
        public GetLatestFeedbackRequest(string? username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}
