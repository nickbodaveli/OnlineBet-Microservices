using Hangfire;
using LeaderBoard.API;
using LeaderBoard.Application;
using LeaderBoard.Infrastructure.BackgroundJobs;
using LeaderBoard.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();


var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();
recurringJobManager.AddOrUpdate<HourlyJob>(
    "run-hourly-job",
    job => job.Run(),
    "* * * * *" 
);


app.UseApiServices();
app.UseHangfireDashboard();

app.Run();
