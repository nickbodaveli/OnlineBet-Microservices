using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Hub.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
