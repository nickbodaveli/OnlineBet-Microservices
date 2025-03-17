using BuildingBlocks.Messaging.Events;
using LeaderBoard.Application.Bets.Commands;
using LeaderBoard.Application.Dtos;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LeaderBoard.Application.Bets.EventHandlers
{
    public class BetCreatedEventHandler
        (ISender sender, ILogger<BetCreatedEventHandler> logger)
        : IConsumer<BetCreatedEvent>
    {
        public async Task Consume(ConsumeContext<BetCreatedEvent> context)
        {
            // TODO: Create new order and start order fullfillment process
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

            var command = MapToCreateBetCommand(context.Message);
            await sender.Send(command);
        }

        private CreateBetCommand MapToCreateBetCommand(BetCreatedEvent message)
        {
            var betDto = new BetDto(
                UserId: message.UserId,
                GameId: message.GameId,
                Amount: message.Amount,
                Timestamp: message.OccurredOn,
                Status: message.Status);

            return new CreateBetCommand(betDto);
        }
    }
}
