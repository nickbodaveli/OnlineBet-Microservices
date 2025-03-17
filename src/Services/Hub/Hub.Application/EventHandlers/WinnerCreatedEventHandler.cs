using BuildingBlocks.Messaging.Events;
using Hub.Application.Data;
using Hub.Application.Data.Integration;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Hub.Application.EventHandlers
{
    public class WinnerCreatedEventHandler
        (ISender sender, ILogger<WinnerCreatedEventHandler> logger, IApplicationDbContext dbContext, IHubContext<NotificationHub> hubContext)
        : IConsumer<WinnerCreatedEvent>
    {
        public async Task Consume(ConsumeContext<WinnerCreatedEvent> context)
        {
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

            var user = dbContext.Users.Where(x => x.Id == context.Message.UserId).FirstOrDefault();

            bool isOnline;

            if(user != null && user.RefreshTokenExpiry <= DateTime.UtcNow)
            {
                isOnline = true;
            }

            var message = $"Congratulations {context.Message.UserId}, you won a prize of {context.Message.PrizeAmount}!";
            await hubContext.Clients.User(context.Message.UserId.ToString()).SendAsync("ReceivePrizeNotification", message);
        }
    }
}
