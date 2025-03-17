using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBoard.Application.Dtos;
using LeaderBoard.Domain.Models;

namespace LeaderBoard.Application.Extensions
{
    public static class BetsExtension
    {
        public static IEnumerable<BetDto> ToBetDtoList(this IEnumerable<Bet> bets)
        {
            return bets.Select(bet => new BetDto(
               UserId: bet.UserId,
               GameId: bet.GameId,
               Amount: bet.Amount,
               Timestamp: bet.Timestamp,
               Status: bet.Status.ToString()
            ));
        }
    }
}
