using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Game.Domain.Models;
using Game.Domain.ValueObjects;

namespace Game.Infrastructure.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Domain.Models.Game>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Game> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasConversion(
                    id => id.Value,
                    value => GameId.Of(value)
                );

            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Description).IsRequired();
        }
    }
}
