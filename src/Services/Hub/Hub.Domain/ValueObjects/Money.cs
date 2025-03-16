using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Domain.ValueObjects
{
    public record Money
    {
        public string Amount { get; } = default!;

        protected Money()
        {
        }

        private Money(string amount)
        {
            Amount = amount;
        }

        public static Money Of(string amount)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(amount);

            return new Money(amount);
        }
    }
}
