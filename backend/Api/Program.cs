using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Services;
using Api.Controllers;
using Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Configuring JWT
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings") // reads from appsettings.json "JwtSettings" section
);
var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>();

var key = Encoding.ASCII.GetBytes(jwtSettings!.Key);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // set to true if you have an issuer
        ValidIssuer = "TownVoice",
        ValidateAudience = true, // set to true if you have an audience
        ValidAudience = "TownVoice",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true
    };
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PostsService>();
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IOptions<JwtSettings>>().Value);
builder.Services.AddScoped<JwtService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<TVDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }  // Allows for E2E tests using the actual server