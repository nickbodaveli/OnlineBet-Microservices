using LeaderBoard.Application.Bets.Queries.GetBets;
using MediatR;

namespace LeaderBoard.Infrastructure.BackgroundJobs
{
    public class HourlyJob
    {
        private readonly ISender _sender;
        public HourlyJob(ISender sender)
        {
            _sender = sender;
        }

        public async Task Run()
        {
            await _sender.Send(new GetBetsQuery(new BuildingBlocks.Pagination.PaginationRequest(0, 10)));
        }
    }
}
