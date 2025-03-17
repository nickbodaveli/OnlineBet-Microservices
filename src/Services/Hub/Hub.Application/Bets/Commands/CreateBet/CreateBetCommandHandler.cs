using BuildingBlocks.CQRS;
using BuildingBlocks.Messaging.Events;
using Hub.Application.Data;
using Hub.Application.Dtos;
using Hub.Domain.Models;
using Hub.Domain.ValueObjects;
using Mapster;
using MassTransit;

namespace Hub.Application.Bets.Commands.CreateBet
{
    public class CreateBetCommandHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
          : ICommandHandler<CreateBetCommand, CreateBetResult>
    {
        public async Task<CreateBetResult> Handle(CreateBetCommand command, CancellationToken cancellationToken)
        {
            var bet = CreateNewBet(command.Bet);

            dbContext.Bets.Add(bet);
            await dbContext.SaveChangesAsync(cancellationToken);

            var eventMessage = command.Bet.Adapt<BetCreatedEvent>();

            await publishEndpoint.Publish(eventMessage, cancellationToken);

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
