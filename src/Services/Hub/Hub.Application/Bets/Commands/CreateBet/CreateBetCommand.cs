using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Hub.Application.Dtos;

namespace Hub.Application.Bets.Commands.CreateBet
{
    public record CreateBetCommand(BetDto Bet)
         : ICommand<CreateBetResult>;

    public record CreateBetResult(Guid Id);
}
