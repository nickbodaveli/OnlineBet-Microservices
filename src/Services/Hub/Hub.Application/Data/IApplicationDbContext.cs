using Hub.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Hub.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Bet> Bets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
