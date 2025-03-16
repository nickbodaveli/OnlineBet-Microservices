using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.Abstractions;
using Hub.Domain.Models;

namespace Hub.Domain.Events
{
    public record BetCreatedEvent(Bet bet) : IDomainEvent;
}
