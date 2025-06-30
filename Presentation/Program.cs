using Application;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Presentation.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add FastEndpoints services
builder.Services.AddFastEndpoints()
    .SwaggerDocument();

// Exception middleware
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Register Application and Infrastructure layers
builder.Services.RegisterApplication()
                .RegisterInfrastructure(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
}).UseSwaggerGen();


app.Run();
