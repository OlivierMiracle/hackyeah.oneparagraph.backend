using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OneParagraph.API.Database;
using OneParagraph.Shared.Content;

namespace OneParagraph.API.Endpoints;

public sealed class GetUserStocks : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/get-users-stocks", async (string email, AppDbContext context) =>
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null) return Results.StatusCode(418);

                List<Guid> stocksIds = 
                    await context.StockUsers
                        .Where(su => su.Email == email)
                        .Select(su => su.Stock)
                        .ToListAsync();

                List<Stock> stocks = [];

                foreach (Guid id in stocksIds)
                    stocks.Add(await context.Stocks.FirstAsync(s => s.Id == id));

                return Results.Ok(stocks);
            })
            .RequireAuthorization();
    }
}