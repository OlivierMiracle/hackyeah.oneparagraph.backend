using Microsoft.AspNetCore.Routing;

namespace OneParagraph.API.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}