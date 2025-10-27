using Api.Data;
using Api.Models;
using Api.Password;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class UserService
    {
        private readonly TVDbContext _context;

        public UserService(TVDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            return await _context
                .Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username
                })
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _context
                .Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> RegisterUserAsync(CreateUserRequest userInfo)
        {
            if (await _context.Users.AnyAsync(u => u.Username == userInfo.Username))
                return false;

            var (hash, salt) = PasswordHelper.CreatePasswordHash(userInfo.Password);

            // eventually, add some type of email verification

            var user = new User
            {
                Username = userInfo.Username,
                Email = userInfo.Email,
                Auth = new Auth
                {
                    PasswordHash = hash,
                    PasswordSalt = salt
                }
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> AuthenticateUserAsync(UserLoginRequest userInfo)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == userInfo.Username);
            if (user == null) { return null; }

            bool verified = PasswordHelper.VerifyPasswordHash(userInfo.Password, user.Auth.PasswordHash, user.Auth.PasswordSalt);
            return verified ? user : null;
        }
    }
}
