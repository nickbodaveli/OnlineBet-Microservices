using System.Security.Claims;
using Carter;
using Game.Application.Bets.Commands;
using Game.Application.Dtos;
using Mapster;
using MediatR;

namespace Game.API.Endpoints
{
    public record BetRequest(BetDto Bet);
    public record BetResponse(Guid Id);
    public class CreateBet : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/bet", async (BetRequest request, ISender sender, HttpContext httpContext) =>
            {
                var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return Results.Unauthorized();
                }

                var command = request.Adapt<CreateBetCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<BetResponse>();

                return Results.Created($"/bet/{response.Id}", response);
            })
            .RequireAuthorization() // ⬅️ Protects this endpoint
            .WithName("Bet")
            .Produces<BetResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Bet")
            .WithDescription("Bet");
        }
    }

}
