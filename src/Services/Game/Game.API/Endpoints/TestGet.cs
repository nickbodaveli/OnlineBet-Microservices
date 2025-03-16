using Carter;
using MediatR;

namespace Game.API.Endpoints
{
    public class TestGet : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/test", () => "It works");
        }
    }

}

// app.MapGet("/", () => "Hello, Minimal API in .NET 8!");