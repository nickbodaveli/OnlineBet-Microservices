using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBoard.Domain.Exceptions;

namespace LeaderBoard.Domain.ValueObjects
{
    public record PrizeId
    {
        public Guid Value { get; }
        private PrizeId(Guid value) => Value = value;
        public static PrizeId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("BetId cannot be empty.");
            }

            return new PrizeId(value);
        }
    }
}
