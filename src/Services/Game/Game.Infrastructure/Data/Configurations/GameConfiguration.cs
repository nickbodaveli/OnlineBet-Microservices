using Game.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
