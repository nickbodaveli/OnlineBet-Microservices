using Hub.Application.Users.Commands.Authentication;
using Hub.Domain.Models;

namespace Hub.API.Endpoints.Identity
{
    public record AuthenticateRequest(LoginUserDto Authenticate);
    public record AuthenticateResponse(LoginResponse LoginResponse);
    public class Authenticate : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/authenticate", async (AuthenticateRequest request, ISender sender) =>
            {
                var command = request.Adapt<AuthenticateCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<AuthenticateResponse>();

                return Results.Created($"/users", response);
            })
        .WithName("Authenticate")
        .Produces<AuthenticateResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Authenticate")
        .WithDescription("Authenticate");
        }
    }
}
