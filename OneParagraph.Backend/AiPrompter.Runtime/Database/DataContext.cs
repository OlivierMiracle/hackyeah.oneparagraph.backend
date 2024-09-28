using Microsoft.EntityFrameworkCore;
using OneParagraph.Shared.Content;

namespace AiPrompter.Runtime.Database;

public class DataContext : DbContext
{
    private readonly AppSettings _appSettings;

    public DbSet<IndustryParagraph> IndustryParagraphs { get; set; }

    public DataContext(AppSettings appSettings) 
    {
        _appSettings = appSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _appSettings.DatabaseConnectionString;
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}
