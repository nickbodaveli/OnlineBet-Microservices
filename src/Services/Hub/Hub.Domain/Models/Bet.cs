using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions.Abstractions;
using Hub.Domain.Enums;
using Hub.Domain.Events;
using Hub.Domain.ValueObjects;

namespace Hub.Domain.Models
{
    public class Bet : Aggregate<BetId>
    {
        public int UserId { get; private set; }
        public int GameId { get; private set; }
        public Money Amount { get; private set; } 
        public DateTime Timestamp { get; private set; }
        public BetStatus Status { get; private set; }

        public static Bet Create(BetId id, int userId, int gameId, Money amount)
        {
            var bet = new Bet
            {
                Id = id,
                UserId = userId, 
                GameId = gameId,
                Amount = amount,     
                Timestamp = DateTime.UtcNow,
                Status = BetStatus.Pending
            };

            bet.AddDomainEvent(new BetCreatedEvent(bet));

            return bet;
        }
    }
}
