using Microsoft.EntityFrameworkCore;
using OneParagraph.Shared.Domain.Identity;

namespace OneParagraph.API.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
}