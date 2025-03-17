using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events;
using Hub.Application.Bets.Queries.GetBets;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hub.Application.EventHandlers
{
    public class WinnerCreatedEventHandler
        (ISender sender, ILogger<WinnerCreatedEventHandler> logger)
        : IConsumer<WinnerCreatedEvent>
    {
        public async Task Consume(ConsumeContext<WinnerCreatedEvent> context)
        {
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

            await sender.Send(new GetBetsQuery());
        }
    }
}
