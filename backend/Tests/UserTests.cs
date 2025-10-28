using Microsoft.EntityFrameworkCore;
using Xunit;
using Api.Services;
using Api.Models;
using Api.Controllers;
using Api.Data;
using Api.Password;

using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
public class UserApiTests
{
    private (TVDbContext, UserService, JwtService, UsersController) setupResources()
    {
        var context = new TVDbContext(new DbContextOptionsBuilder<TVDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options
        );
        var userService = new UserService(context);
        var jwtService = new JwtService(new JwtSettings {
            SecretKey = "djsfadk!%adjs12!@$#89@#$120d71289;%@!327akl;3127%!%kl;%!21", // hows that for random
            Issuer = "TownVoice",
            Audience = "TownVoicers",
            ExpiryMinutes = 60
        });
        var usersController = new UsersController(userService, jwtService);
        return (context, userService, jwtService, usersController);
    }

    [Fact]
    public async Task RegisterAndLoginUser_EndToEnd()
    {
        // Arrange
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string email = "test@tester.com";
        string password = "TheExamplePassword12345!!";
        var createUserRequest = new CreateUserRequest { Username = username, Email = email, Password = password };

        // Act: Register
        var registerResult = await usersController.CreateUser(createUserRequest);
        Assert.IsType<OkResult>(registerResult);

        // Act: Login 
        var loginRequest = new UserLoginRequest { Username = username, Password = password };
        var loginResult = await usersController.Login(loginRequest);

        Assert.IsType<OkObjectResult>(loginResult);
    }

    [Fact]
    public async Task RegisterTwoUsersWithSameName_EndToEnd()
    {
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string password = "TheExamplePassword12345!!";
        var createUserRequest1 = new CreateUserRequest { Username = username, Email = "test@tester.com", Password = password };
        var createUserRequest2 = new CreateUserRequest { Username = username, Email = "nottest@tester.com", Password = password + "plussome" };

        // Act: Register
        var registerResult1 = await usersController.CreateUser(createUserRequest1);
        Assert.IsType<OkResult>(registerResult1);
        var registerResult2 = await usersController.CreateUser(createUserRequest2);
        Assert.IsType<ConflictObjectResult>(registerResult2);
    }

    [Fact]
    public async Task RegisterAndLoginWithBadPassword_EndToEnd()
    {
        // Arrange
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string email = "test@tester.com";
        string password = "TheExamplePassword12345!!";
        var createUserRequest = new CreateUserRequest { Username = username, Email = email, Password = password };

        // Act: Register
        var registerResult = await usersController.CreateUser(createUserRequest);
        Assert.IsType<OkResult>(registerResult);

        // Act: Login 
        var loginRequest = new UserLoginRequest { Username = username, Password = "notpassword" };
        var loginResult = await usersController.Login(loginRequest);

        Assert.IsType<UnauthorizedObjectResult>(loginResult);
    }

    [Fact]
    public async Task GetUserById_EndToEnd()
    {
        // Arrange
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string email = "test@tester.com";
        string password = "TheExamplePassword12345!!";
        var createUserRequest = new CreateUserRequest { Username = username, Email = email, Password = password };

        // Act: Register
        var registerResult = await usersController.CreateUser(createUserRequest);
        Assert.IsType<OkResult>(registerResult);

        // Act: Login 
        var getUserResult = await usersController.GetUserById(1);
        Assert.IsType<OkObjectResult>(getUserResult);
    }
}
