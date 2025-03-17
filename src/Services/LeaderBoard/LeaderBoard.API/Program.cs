using LeaderBoard.API;
using LeaderBoard.Application;
using LeaderBoard.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);


var app = builder.Build();

app.UseApiServices();

app.Run();
