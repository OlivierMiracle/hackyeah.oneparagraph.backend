using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OneParagraph.API.Database;
using OneParagraph.Shared.Content;
using OneParagraph.Shared.Enums;

namespace OneParagraph.API.Endpoints;

public sealed class GetIndustryParagraphs : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/get-industry-paragraphs", async (AppDbContext context) =>
            {
                List<IndustryParagraph> paragraphs = [];
                
                foreach (Industries industry in Enum.GetValues<Industries>())
                {
                    var paragraph = await context.IndustryParagraphs.OrderByDescending(i => i.DateTime)
                        .FirstOrDefaultAsync(i => i.Industry == industry);
                    
                    if (paragraph == null) continue;
                    
                    paragraphs.Add(paragraph);
                }

                return paragraphs;
            })
        .RequireAuthorization();
    }
}