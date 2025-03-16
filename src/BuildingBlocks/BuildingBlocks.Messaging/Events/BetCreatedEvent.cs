using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events
{
    public record BetCreatedEvent : IntegrationEvent
    {
        public int UserId { get; set; } = default!;
        public string Amount { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
