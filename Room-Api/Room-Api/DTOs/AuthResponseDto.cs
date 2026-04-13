namespace Room_Api.DTOs
{
    public class AuthResponseDto
    {
    public string Token { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
        public DateTime Expiration { get; set; }

        public string RefreshToken { get; set; }
    }
}
