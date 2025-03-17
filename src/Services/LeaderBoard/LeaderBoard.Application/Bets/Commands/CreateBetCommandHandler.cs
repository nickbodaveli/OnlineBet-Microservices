using BuildingBlocks.CQRS;
using LeaderBoard.Application.Data;
using LeaderBoard.Application.Dtos;
using LeaderBoard.Domain.Models;
using LeaderBoard.Domain.ValueObjects;
using MassTransit;

namespace LeaderBoard.Application.Bets.Commands
{
    public class CreateBetCommandHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
            : ICommandHandler<CreateBetCommand, CreateBetResult>
    {
        public async Task<CreateBetResult> Handle(CreateBetCommand command, CancellationToken cancellationToken)
        {
            var bet = CreateNewBet(command.Bet);

            dbContext.Bets.Add(bet);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateBetResult(bet.Id.Value);
        }

        private Bet CreateNewBet(BetDto betDto)
        {
            var newOrder = Bet.Create(
                    id: BetId.Of(Guid.NewGuid()),
                    userId: betDto.UserId,
                    gameId: betDto.GameId,
                    amount: betDto.Amount
                    );

            return newOrder;
        }
    }
}
