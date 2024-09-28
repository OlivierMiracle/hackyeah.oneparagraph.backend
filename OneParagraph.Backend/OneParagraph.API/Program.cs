// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OneParagraph.API.Database;
using OneParagraph.API.EndpointExtensions;
using OneParagraph.API.Extensions;
using Swashbuckle.AspNetCore.Filters;

Console.WriteLine("***** BOBER");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddAuthorization();

builder.Services
    .AddMvcCore()
    .AddApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = configuration["DbConnectionString"];
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

WebApplication app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials()
);

app.MapEndpoints();

app.UseSwaggerWithUi();

app.ApplyMigrations();

app.UseHttpsRedirection();

app.MapIdentityApi<IdentityUser>();

app.UseAuthorization();

app.Run();
