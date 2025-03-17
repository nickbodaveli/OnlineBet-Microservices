using Domain.Abstractions.Abstractions;
using LeaderBoard.Domain.ValueObjects;

namespace LeaderBoard.Domain.Models
{
    public class LeaderBoard : Aggregate<LeaderBoardId>
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string TotalBetAmount { get; set; }
    }
}
