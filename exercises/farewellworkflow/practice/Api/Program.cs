using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/get-spanish-greeting", ([FromQuery] string? name) =>
{
    if (string.IsNullOrEmpty(name))
    {
        return Results.BadRequest(
            "Missing required name parameter. Please add ?name=tina to the end of the url.");
    }

    return Results.Ok($"¡Hola, {name}!");
});

app.MapGet("/get-spanish-farewell", ([FromQuery] string? name) =>
{
    if (string.IsNullOrEmpty(name))
    {
        return Results.BadRequest(
            "Missing required name parameter. Please add ?name=tina to the end of the url.");
    }

    return Results.Ok($"¡Adiós, {name}!");
});

app.Run();
