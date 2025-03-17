using Hub.API;
using Hub.Application;
using Hub.Application.Data.Integration;
using Hub.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration)
    .AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<NotificationHub>("/notificationHub");

if (app.Environment.IsDevelopment())
{
}

app.Run();