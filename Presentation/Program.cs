using Application;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure;
using Presentation.ExceptionHandling;
using FastEndpoints.Security;

var builder = WebApplication.CreateBuilder(args);

// Add FastEndpoints services
builder.Services
    .AddFastEndpoints();

// Exception middleware
//builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // *** THIS IS CRITICAL FOR COOKIES ***
    });
});

// Register Application and Infrastructure layers
builder.Services.RegisterApplication()
                .RegisterInfrastructure(builder.Configuration);

builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = builder.Configuration["JWT:Key"])
   .AddAuthorization()
   .SwaggerDocument();

var app = builder.Build();

//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
}).UseSwaggerGen().UseAuthorization();


app.Run();
