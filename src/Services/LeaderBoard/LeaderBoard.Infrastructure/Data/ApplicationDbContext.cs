using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LeaderBoard.Application.Data;
using LeaderBoard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaderBoard.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Bet> Bets => Set<Bet>();
        public DbSet<Domain.Models.LeaderBoard> LeaderBoards => Set<Domain.Models.LeaderBoard>();
        public DbSet<Prize> Prizes => Set<Prize>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
