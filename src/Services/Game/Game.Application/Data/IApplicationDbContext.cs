using Microsoft.EntityFrameworkCore;

namespace Game.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Models.Game> Games { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
