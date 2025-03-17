using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
