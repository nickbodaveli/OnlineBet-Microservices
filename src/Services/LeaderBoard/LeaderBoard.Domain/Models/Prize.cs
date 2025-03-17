using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions.Abstractions;
using LeaderBoard.Domain.ValueObjects;

namespace LeaderBoard.Domain.Models
{
    public class Prize : Aggregate<PrizeId>
    {
        public LeaderBoardId LeaderBoardId { get; set; }
        public int UserId { get; set; }
        public int Name { get; set; }
    }
}
