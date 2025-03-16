using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.Abstractions;
using Hub.Domain.Enums;
using Hub.Domain.Events;
using Hub.Domain.ValueObjects;

namespace Hub.Domain.Models
{
    public class Bet : Aggregate<BetId>
    {
        public int UserId { get; private set; }
        public Money Amount { get; private set; } 
        public DateTime Timestamp { get; private set; }
        public BetStatus Status { get; private set; }

        public static Bet Create(BetId id, int userId, Money amount)
        {
            var bet = new Bet
            {
                Id = id,
                UserId = userId, 
                Amount = amount,     
                Timestamp = DateTime.UtcNow,
                Status = BetStatus.Pending
            };

            bet.AddDomainEvent(new BetCreatedEvent(bet));

            return bet;
        }

        // Convert Money back to its components (amount and currency)
        //public (decimal Amount, string Currency) GetAmountDetails() => (Amount.Amount, Amount.Currency);
    }
}
