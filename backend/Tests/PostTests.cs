using Microsoft.EntityFrameworkCore;
using Xunit;
using Api.Services;
using Api.Models;
using Api.Controllers;
using Api.Data;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

public class PostApiTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;
    public PostApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
            });
        });
    }

    private void ClearDatabase(TVDbContext dbContext)
    {
        dbContext.Users.RemoveRange(dbContext.Users);
        dbContext.Posts.RemoveRange(dbContext.Posts);
        dbContext.SaveChanges();
    }

    [Fact]
    public async Task CreateUpdateDeletePostWithValidJWT_EndToEnd()
    {
        HttpClient client = _factory.CreateClient();
        using var scope = _factory.Services.CreateScope();
        TVDbContext dbContext = scope.ServiceProvider.GetRequiredService<TVDbContext>();
        ClearDatabase(dbContext);
        // Arrange
        // Create user
        string username = "john";
        string name = "John Dingle";
        string email = "test@tester.com";
        string password = "P@ssw0rd!";
        var createUserRequest = new CreateUserRequest { Username = username, Name = name, Email = email, Password = password };
        var createUserResponse = await client.PostAsJsonAsync("/api/users/register", createUserRequest);
        createUserResponse.EnsureSuccessStatusCode();

        // Login and store JWT
        var loginRequest = new UserLoginRequest { Username = username, Password = password };
        var loginResponse = await client.PostAsJsonAsync("/api/users/login", loginRequest);
        loginResponse.EnsureSuccessStatusCode();
        var loginResult = await loginResponse.Content.ReadFromJsonAsync<UserLoginResponse>();
        string jwt = loginResult!.Token;
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

        // Test CRUD endpoints
        var postRequest = new CreatePostDTO
        {
            Content = "Hello world!"
        };
        var makePostResponse = await client.PutAsJsonAsync("/api/posts/create", postRequest);
        makePostResponse.EnsureSuccessStatusCode();
        var makePostResult = await makePostResponse.Content.ReadFromJsonAsync<CreatePostDTO>();
        var postId = makePostResult!.Id;

        var updatePostRequest = new UpdatePostDTO
        {
            Id = postId,
            NewContent = "Goodbye world!"
        };
        var updatePostResponse = await client.PostAsJsonAsync("/api/posts/update", updatePostRequest);
        updatePostResponse.EnsureSuccessStatusCode();

        var deletePostRequest = new DeletePostDTO
        {
            Id = postId
        };
        var deletePostResponse = await client.PostAsJsonAsync("/api/posts/delete", deletePostRequest);
        deletePostResponse.EnsureSuccessStatusCode();

        var post = await dbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        Assert.Equal("Goodbye world!", post!.Content);
        Assert.NotNull(post!.UpdatedAt);
        Assert.True(post!.IsDeleted);
    }
    [Fact]
    public async Task CreatePostWithoutJWT_EndToEnd()
    {
        HttpClient client = _factory.CreateClient();
        using var scope = _factory.Services.CreateScope();
        TVDbContext dbContext = scope.ServiceProvider.GetRequiredService<TVDbContext>();
        ClearDatabase(dbContext);

        var postRequest = new CreatePostDTO
        {
            Content = "Hello world!"
        };
        var makePostResponse = await client.PutAsJsonAsync("/api/posts/create", postRequest);
        Assert.Equal(HttpStatusCode.Unauthorized, makePostResponse.StatusCode);
    }

    [Fact]
    public async Task DeleteOrEditAnotherUserPost_EndToEnd()
    {

        HttpClient client = _factory.CreateClient();
        using var scope = _factory.Services.CreateScope();
        TVDbContext dbContext = scope.ServiceProvider.GetRequiredService<TVDbContext>();
        UserService userService = new UserService(dbContext);
        PostsService postsService = new PostsService(dbContext);
        ClearDatabase(dbContext);

        // Create user
        string username = "john";
        string name = "John Dingle";
        string email = "test@tester.com";
        string password = "P@ssw0rd!";
        var createUserRequest = new CreateUserRequest { Username = username, Name = name, Email = email, Password = password };
        var createUserResponse = await client.PostAsJsonAsync("/api/users/register", createUserRequest);
        createUserResponse.EnsureSuccessStatusCode();

        // Login and store JWT
        var loginRequest = new UserLoginRequest { Username = username, Password = password };
        var loginResponse = await client.PostAsJsonAsync("/api/users/login", loginRequest);
        loginResponse.EnsureSuccessStatusCode();
        var loginResult = await loginResponse.Content.ReadFromJsonAsync<UserLoginResponse>();
        string jwt = loginResult!.Token;
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

        // Create a post from another user
        var newUser = await userService.RegisterUserAsync(new CreateUserRequest
        {
            Username = "tester2",
            Name = "tester2",
            Email = "tester@test.com",
            Password = "P@ssw0rd!",
        });
        var (_, newPost) = await postsService.CreatePost(newUser!.Id, "Not Hello World!");
        int postId = newPost!.Id;

        // Attempt to edit and delete
        var updatePostRequest = new UpdatePostDTO
        {
            Id = postId,
            NewContent = "Goodbye world!"
        };
        var updatePostResponse = await client.PostAsJsonAsync("/api/posts/update", updatePostRequest);
        Assert.Equal(HttpStatusCode.Unauthorized, updatePostResponse.StatusCode);

        var deletePostRequest = new DeletePostDTO
        {
            Id = postId
        };
        var deletePostResponse = await client.PostAsJsonAsync("/api/posts/delete", deletePostRequest);
        Assert.Equal(HttpStatusCode.Unauthorized, deletePostResponse.StatusCode);

    }
    public void Dispose()
    {
        using var scope = _factory.Services.CreateScope();
        TVDbContext dbContext = scope.ServiceProvider.GetRequiredService<TVDbContext>();
        ClearDatabase(dbContext);
    }
}
