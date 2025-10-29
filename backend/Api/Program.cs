using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Services;
using Api.Controllers;
using Api.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<UserService>();
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings") // reads from appsettings.json "JwtSettings" section
);
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
