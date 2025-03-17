using LeaderBoard.Domain.Exceptions;

namespace LeaderBoard.Domain.ValueObjects
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
                throw new DomainException("BetId cannot be empty.");
            }

            return new BetId(value);
        }
    }
}
