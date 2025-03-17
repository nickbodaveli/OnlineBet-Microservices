using Domain.Abstractions.Abstractions;
using Hub.Domain.Models;

namespace Hub.Domain.Events
{
    public record BetCreatedEvent(Bet bet) : IDomainEvent;
}
