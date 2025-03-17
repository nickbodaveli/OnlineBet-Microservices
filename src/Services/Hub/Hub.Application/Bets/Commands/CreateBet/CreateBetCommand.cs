using BuildingBlocks.CQRS;
using Hub.Application.Dtos;

namespace Hub.Application.Bets.Commands.CreateBet
{
    public record CreateBetCommand(BetDto Bet)
         : ICommand<CreateBetResult>;

    public record CreateBetResult(Guid Id);
}
