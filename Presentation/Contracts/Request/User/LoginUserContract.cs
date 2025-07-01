namespace Presentation.Contracts.Request.User
{
    public class LoginUserContract
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
