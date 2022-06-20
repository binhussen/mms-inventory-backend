namespace DataModel.Models.DTOs.User
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
