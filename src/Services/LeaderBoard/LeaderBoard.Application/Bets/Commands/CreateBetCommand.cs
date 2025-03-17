using BuildingBlocks.CQRS;
using LeaderBoard.Application.Dtos;

namespace LeaderBoard.Application.Bets.Commands
{
    public record CreateBetCommand(BetDto Bet)
       : ICommand<CreateBetResult>;

    public record CreateBetResult(Guid Id);
}
