using BuildingBlocks.Pagination;
using Carter;
using LeaderBoard.Application.Bets.Queries.GetOrders;
using LeaderBoard.Application.Dtos;
using Mapster;
using MediatR;

namespace LeaderBoard.API.Endpoints
{
    public record GetBetsResponse(PaginatedResult<BetDto> Bets);

    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/getbets", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetBetsQuery(request));

                var response = result.Adapt<GetBetsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetBets")
            .Produces<GetBetsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Bets")
            .WithDescription("Get Bets");
        }
    }
}
