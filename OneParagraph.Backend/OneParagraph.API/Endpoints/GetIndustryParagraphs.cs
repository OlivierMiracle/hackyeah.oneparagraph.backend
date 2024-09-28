using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OneParagraph.API.Database;
using OneParagraph.Shared.Content;

namespace OneParagraph.API.Endpoints;

public sealed class GetIndustryParagraphs : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/get-industry-paragraphs", async (AppDbContext context) =>
            {
                List<IndustryParagraph> paragraphs = await context.IndustryParagraphs
                    .OrderByDescending(c => c.DateTime)
                    .Take(15)
                    .ToListAsync();

                return paragraphs;
            })
        .RequireAuthorization();
    }
}