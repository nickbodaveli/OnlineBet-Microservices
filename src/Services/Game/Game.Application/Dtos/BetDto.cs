using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Dtos
{
    public record BetDto
    (
        int UserId,
        int GameId,
        MoneyDto Amount,
        DateTime Timestamp
    );
}
