using BuildingBlocks.CQRS;
using Game.Application.Dtos;

namespace Game.Application.Bets.Commands
{
    public record CreateBetCommand(BetDto Bet)
       : ICommand<CreateBetResult>;

    public record CreateBetResult(Guid Id);
}
