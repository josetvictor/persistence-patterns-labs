using Microsoft.EntityFrameworkCore;

namespace PatternsLabs.DAO;

public class AppDbContext : DbContext
{
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite("Data Source=app.db;Cache=Shared");
}
