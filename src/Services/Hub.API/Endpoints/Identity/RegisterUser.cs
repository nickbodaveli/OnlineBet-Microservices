using Carter;
using Hub.Application.Dtos;
using Hub.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Hosting.Server;

namespace Hub.API.Endpoints.Identity
{
    public record RegisterUserRequest(RegisterUserDto Register);
    public record RegisterUserResponse(bool IsRegistered);
    public class RegisterUser : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/register", async (RegisterUserRequest request, ISender sender) =>
            {
                var command = request.Adapt<RegisterUserCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<RegisterUserResponse>();

                return Results.Created($"/users", response);
            })
        .WithName("RegisterUser")
        .Produces<RegisterUserResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Register User")
        .WithDescription("Register User");
        }
    }
}
