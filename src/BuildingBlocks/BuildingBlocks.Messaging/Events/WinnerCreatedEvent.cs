using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events
{
    public record WinnerCreatedEvent : IntegrationEvent
    {
        public int UserId { get; set; } = default!;
        public int GameId { get; set; } = default!;
        public decimal PrizeAmount { get; set; } = default!;
        public int Place { get; set; }
    }
}
