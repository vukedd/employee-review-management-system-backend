namespace Presentation.Contracts.Response.Auth
{
    public class RefreshTokenResponse
    {
        public RefreshTokenResponse(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; set; }
    }
}
