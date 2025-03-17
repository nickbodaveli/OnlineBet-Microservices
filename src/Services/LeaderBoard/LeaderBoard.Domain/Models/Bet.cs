using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions.Abstractions;
using LeaderBoard.Domain.Enums;
using LeaderBoard.Domain.ValueObjects;

namespace LeaderBoard.Domain.Models
{
    public class Bet : Aggregate<BetId>
    {
        public int UserId { get; private set; }
        public int GameId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Timestamp { get; private set; }
        public BetStatus Status { get; private set; }

        public static Bet Create(BetId id, int userId, int gameId, decimal amount)
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

            return bet;
        }
    }
}
