namespace Api.Models
{
    public class UserDTO
    {
        public required int Id;
        public string? Username;
        public string? Name;
    }
    public class PasswordChangeRequest
    {
        public required string Username;
        public required string OldPassword;
        public required string NewPassword;
    }
    public class CreateUserRequest
    {
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
    public class UserLoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}