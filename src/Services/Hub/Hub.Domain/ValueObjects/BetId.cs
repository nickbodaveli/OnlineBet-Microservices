using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.Exceptions;

namespace Hub.Domain.ValueObjects
{
    public record BetId
    {
        public Guid Value { get; }
        private BetId(Guid value) => Value = value;
        public static BetId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("OrderId cannot be empty.");
            }

            return new BetId(value);
        }
    }
}
