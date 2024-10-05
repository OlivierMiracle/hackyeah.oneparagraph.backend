using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OneParagraph.Shared.Content;
using OneParagraph.Shared.Identity;

namespace OneParagraph.API.Database;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<IndustryParagraph> IndustryParagraphs { get; set; }
    public DbSet<StockParagraph> StockParagraphs { get; set; }
    public DbSet<StockUser> StockUsers { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    
    //DbSert of users using User model inheriting from IdentityUser
    public new DbSet<User> Users { get; set; }
    public AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration["DbConnectionString"];
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<IdentityUser>()
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .Entity<StockUser>()
            .HasKey(c => new { c.Email, c.Stock });
        
        base.OnModelCreating(builder);
    }
}