using Infrastructure;
using Application;
using Presentation.ExceptionHandling;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add FastEndpoints services
builder.Services.AddFastEndpoints();


// Exception middleware
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Register Application and Infrastructure layers
builder.Services.RegisterApplication()
                .RegisterInfrastructure(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting(); 

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});


app.Run();
