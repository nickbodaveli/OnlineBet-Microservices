using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Application.Dtos
{
    public record BetDto
    (
        int UserId,
        int GameId,
        decimal Amount,
        DateTime Timestamp,
        string Status
    );
}
