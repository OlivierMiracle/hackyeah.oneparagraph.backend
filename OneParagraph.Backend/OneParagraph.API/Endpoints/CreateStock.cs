using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OneParagraph.API.Database;
using OneParagraph.Shared.Content;

namespace OneParagraph.API.Endpoints;

public sealed class CreateStock : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/create-stock", async (RequestW request, AppDbContext context) =>
        {
            var stock = new Stock()
            {
                Id = Guid.NewGuid(),
                Symbol = request.Symbol,
                Name = request.Symbol   // From Yahoo Finance API
            };

            context.Stocks.Add(stock);

            await context.SaveChangesAsync();

            return Results.Ok();
        })
        .RequireAuthorization();
    }

    internal class RequestW
    {
        public string Symbol { get; set; }
    }
}
