using Game.API;
using Game.Application;
using Game.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);


// Add HttpClient for API Gateway
builder.Services.AddHttpClient("ApiGatewayClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7000/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
});







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