using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    using Api.Models;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ExampleModel> ExampleTable { get; set; }
    }
}
