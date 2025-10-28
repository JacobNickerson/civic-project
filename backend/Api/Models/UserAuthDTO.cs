namespace Api.Models
{
    public class PasswordChangeRequest
    {
        public required string Username;
        public required string OldPassword;
        public required string NewPassword;
    }
    public class CreateUserRequest
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "";
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public int ExpiryMinutes { get; set; } = 60;
    }
    public class UserLoginRequest
    {
        public required string Username;
        public required string Password;
    }
}