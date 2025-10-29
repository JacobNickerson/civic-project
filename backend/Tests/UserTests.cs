using Microsoft.EntityFrameworkCore;
using Xunit;
using Api.Services;
using Api.Models;
using Api.Controllers;
using Api.Data;

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
            Key = "djsfadk!%adjs12!@$#89@#$120d71289;%@!327akl;3127%!%kl;%!21", // hows that for random
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
        string name = "John Dingle";
        string email = "test@tester.com";
        string password = "TheExamplePassword12345!!";
        var createUserRequest = new CreateUserRequest { Username = username, Name = name, Email = email, Password = password };

        // Act: Register
        var registerResult = await usersController.CreateUser(createUserRequest);
        var okResult = Assert.IsType<OkObjectResult>(registerResult);
        var registerReturnValues = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal(registerReturnValues.Username, username);
        Assert.Equal(registerReturnValues.Name, name);
        Assert.Null(registerReturnValues.Bio);
        Assert.Null(registerReturnValues.ProfilePic);

        // Act: Login 
        var loginRequest = new UserLoginRequest { Username = username, Password = password };
        var loginResult = await usersController.Login(loginRequest);

        okResult = Assert.IsType<OkObjectResult>(loginResult);
        var loginReturnValues = Assert.IsType<UserLoginResponse>(okResult.Value);
        Assert.Equal(1,loginReturnValues.UserId);
        Assert.NotNull(loginReturnValues.Token);
    }

    [Fact]
    public async Task RegisterTwoUsersWithSameName_EndToEnd()
    {
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string name = "John Dingle";
        string password = "TheExamplePassword12345!!";
        var createUserRequest1 = new CreateUserRequest { Username = username, Name = name, Email = "test@tester.com", Password = password };
        var createUserRequest2 = new CreateUserRequest { Username = username, Name = "John Dongle", Email = "nottest@tester.com", Password = password + "plussome" };

        // Act: Register
        var registerResult1 = await usersController.CreateUser(createUserRequest1);
        Assert.IsType<OkObjectResult>(registerResult1);
        var registerResult2 = await usersController.CreateUser(createUserRequest2);
        Assert.IsType<ConflictObjectResult>(registerResult2);
    }

    [Fact]
    public async Task RegisterAndLoginWithBadPassword_EndToEnd()
    {
        // Arrange
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string name = "John Dingle";
        string email = "test@tester.com";
        string password = "TheExamplePassword12345!!";
        var createUserRequest = new CreateUserRequest { Username = username, Name = name, Email = email, Password = password };

        // Act: Register
        var registerResult = await usersController.CreateUser(createUserRequest);
        Assert.IsType<OkObjectResult>(registerResult);

        // Act: Login 
        var loginRequest = new UserLoginRequest { Username = username, Password = "notpassword" };
        var loginResult = await usersController.Login(loginRequest);

        Assert.IsType<UnauthorizedObjectResult>(loginResult);
    }

    [Fact]
    public async Task GetUserByIdNoOptionalFields_EndToEnd()
    {
        // Arrange
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string name = "John Dingle";
        string email = "test@tester.com";
        string password = "TheExamplePassword12345!!";
        var createUserRequest = new CreateUserRequest { Username = username, Name = name, Email = email, Password = password };

        // Act: Register
        var registerResult = await usersController.CreateUser(createUserRequest);
        Assert.IsType<OkObjectResult>(registerResult);

        // Act: Login 
        var getUserResult = await usersController.GetUserById(1);
        Assert.IsType<OkObjectResult>(getUserResult);
    }

    [Fact]
    public async Task GetUserById_EndToEnd()
    {
        // Arrange
        var (_, _, _, usersController) = setupResources();
        string username = "john";
        string name = "John Dingle";
        string email = "test@tester.com";
        string password = "TheExamplePassword12345!!";
        string bio = "I am a tester";
        string profilepic = "https://pic.img/";
        var createUserRequest = new CreateUserRequest {
            Username = username,
            Name = name,
            Email = email,
            Password = password,
            Bio = bio,
            ProfilePic = profilepic
        };

        // Act: Register
        var registerResult = await usersController.CreateUser(createUserRequest);
        Assert.IsType<OkObjectResult>(registerResult);

        // Act: Login 
        var getUserResult = await usersController.GetUserById(1);
        var okResult = Assert.IsType<OkObjectResult>(getUserResult);
        var returnValues = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal(returnValues.Username, username);
        Assert.Equal(returnValues.Name, name);
        Assert.Equal(returnValues.Bio, bio);
        Assert.Equal(returnValues.ProfilePic, profilepic);
    }
}
