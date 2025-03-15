using Hub.API;
using Hub.Application;
using Hub.Infrastructure;
using Hub.Infrastructure.Data.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{

    //app.MapGet("/", () => "Hello World!");
    //await app.InitialiseDatabaseAsync();
}

app.Run();