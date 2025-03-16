using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.ValueObjects;

namespace Hub.Application.Dtos
{
    public record BetDto
    (
        int UserId,
        MoneyDto Amount,
        DateTime Timestamp
    );
}
