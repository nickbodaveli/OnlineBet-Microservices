using Carter;
using Hub.Application.Dtos;
using Hub.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Hosting.Server;

namespace Hub.API.Endpoints.Identity
{
    public record RegisterUserRequest(LoginUserDto login);
    public record RegisterUserResponse(bool isRegistered);
    public class RegisterUser : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (RegisterUserRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateUserCommand>();

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
