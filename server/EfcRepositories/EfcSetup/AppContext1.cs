using EfcRepositories.EfcSetup.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EfcRepositories.EfcSetup;

public class AppContext1 : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\mikke\RiderProjects\AssignmentForDnp\server\EfcRepositories\app.db"); 
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
    }
}