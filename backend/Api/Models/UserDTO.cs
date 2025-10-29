namespace Api.Models
{
    public class UserDTO
    {
        public required int Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? ProfilePic { get; set; }
        public string? Bio { get; set; }
    }
    public class PasswordChangeRequest
    {
        public required string Username { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
    public class CreateUserRequest
    {
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? ProfilePic { get; set; }
        public string? Bio { get; set; }
    }
    public class UserLoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
    public class UserLoginResponse
    {
        public required int UserId { get; set; } 
        public required string Token { get; set; }
    }
}