using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Game.Application.Dtos;

namespace Game.Application.Bets.Commands
{
    public record CreateBetCommand(BetDto Bet)
       : ICommand<CreateBetResult>;

    public record CreateBetResult(Guid Id);
}
