// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using OneParagraph.API.EndpointExtensions;
using OneParagraph.API.Extensions;

Console.WriteLine("Hello, World!");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

WebApplication app = builder.Build();

app.MapEndpoints();

app.UseSwaggerWithUi();

app.ApplyMigrations();

app.UseHttpsRedirection();

app.Run();
