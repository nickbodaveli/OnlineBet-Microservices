using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using LeaderBoard.Application.Dtos;

namespace LeaderBoard.Application.Bets.Queries.GetBets
{
    public record GetBetsQuery(PaginationRequest PaginationRequest)
      : IQuery<GetBetsResult>;

    public record GetBetsResult(PaginatedResult<BetDto> Bets);
}
