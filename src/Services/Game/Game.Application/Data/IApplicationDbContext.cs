using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Game.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Models.Game> Games { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
