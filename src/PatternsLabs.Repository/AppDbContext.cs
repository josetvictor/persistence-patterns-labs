using Microsoft.EntityFrameworkCore;

namespace PatternsLabs.Repository;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite("Data Source=app.db;Cache=Shared");
}
