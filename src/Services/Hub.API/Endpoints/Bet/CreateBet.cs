using Hub.Application.Bets.Commands.CreateBet;

namespace Hub.API.Endpoints.Bet
{
    public record BetRequest(BetDto Bet);
    public record BetResponse(Guid Id);
    public class CreateBet : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/bet", async (BetRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateBetCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<BetResponse>();

                return Results.Created($"/bets", response);
            })
        .WithName("Bet")
        .Produces<BetResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Bet")
        .WithDescription("Bet");
        }
    }
}
