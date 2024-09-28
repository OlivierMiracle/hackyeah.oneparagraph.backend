using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OneParagraph.API.Database;

namespace OneParagraph.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using AppDbContext dbDbContext =
            scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbDbContext.Database.Migrate();
    }
}