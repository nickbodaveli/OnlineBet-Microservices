using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.Exceptions;

namespace Hub.Domain.ValueObjects
{
    public record NotificationId
    {
        public Guid Value { get; }
        private NotificationId(Guid value) => Value = value;
        public static NotificationId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("BetId cannot be empty.");
            }

            return new NotificationId(value);
        }
    }
}
