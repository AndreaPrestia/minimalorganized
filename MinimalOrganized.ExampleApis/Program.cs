using Microsoft.AspNetCore.Mvc;
using MinimalOrganized;
using MinimalOrganized.ExampleApis;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/", ([FromBody] TestRequestModel model) => Results.Created("/", model))
    .ValidateRequest<TestRequestModel>()
    .WithName("TestPostWithValidation");

app.UseApiRouters();

app.Run();