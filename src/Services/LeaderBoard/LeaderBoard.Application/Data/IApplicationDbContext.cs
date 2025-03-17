using LeaderBoard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaderBoard.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Bet> Bets { get; }
        DbSet<Domain.Models.LeaderBoard> LeaderBoards { get; }
        DbSet<Prize> Prizes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
