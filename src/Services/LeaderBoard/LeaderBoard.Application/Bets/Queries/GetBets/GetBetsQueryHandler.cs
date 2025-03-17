using BuildingBlocks.CQRS;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Pagination;
using LeaderBoard.Application.Data;
using LeaderBoard.Application.Dtos;
using LeaderBoard.Application.Extensions;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace LeaderBoard.Application.Bets.Queries.GetBets
{
    public class GetBetsQueryHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
    : IQueryHandler<GetBetsQuery, GetBetsResult>
    {
        public async Task<GetBetsResult> Handle(GetBetsQuery query, CancellationToken cancellationToken)
        {
            var startTime = DateTime.UtcNow.AddHours(-1);
            var endTime = DateTime.UtcNow;

            var lastHourBets = await dbContext.Bets
                .Where(x => x.Timestamp >= startTime && x.Timestamp <= endTime)
                .ToListAsync(cancellationToken); 

            var winners = lastHourBets
                .GroupBy(b => new { b.UserId, b.GameId })
                .Select(g => new
                {
                    UserId = g.Key.UserId,
                    GameId = g.Key.GameId,
                    TotalBetAmount = g.Sum(b => b.Amount)
                })
                .OrderByDescending(p => p.TotalBetAmount)
                .Take(3)
                .Select((player, index) => new WinnerCreatedEvent
                {
                    UserId = player.UserId,
                    GameId = player.GameId,
                    PrizeAmount = GetPrizeAmount(index + 1),
                    Place = index + 1
                })
                .ToList();

            foreach (var winner in winners)
            {
                await publishEndpoint.Publish(winner, cancellationToken);
            }

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Bets.LongCountAsync(cancellationToken);

            var bets = await dbContext.Bets
                .Where(x => x.Timestamp >= startTime && x.Timestamp <= endTime) 
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken); 

            return new GetBetsResult(
                new PaginatedResult<BetDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    bets.ToBetDtoList()));
        }

        private decimal GetPrizeAmount(int place)
        {
            return place switch
            {
                1 => 1000m,
                2 => 500m,
                3 => 250m,
                _ => 0m
            };
        }
    }
}
