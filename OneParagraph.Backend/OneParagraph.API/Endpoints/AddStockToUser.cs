using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OneParagraph.API.Database;
using OneParagraph.Shared.Content;

namespace OneParagraph.API.Endpoints;

public sealed class AddStockToUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("api/add-stock-to-user", async (Request request, AppDbContext context) =>
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                return Results.StatusCode(418);

            context.StockUsers.Add(new StockUser { Email = request.Email, Stock = request.StockId });

            await context.SaveChangesAsync();

            return Results.Ok();
        })
            .RequireAuthorization();
    }

    internal class Request
    {
        public string Email { get; set; }
        public Guid StockId { get; set; }
    }
}