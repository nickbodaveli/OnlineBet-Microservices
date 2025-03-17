using LeaderBoard.Domain.Models;
using LeaderBoard.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaderBoard.Infrastructure.Data.Configurations
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasConversion(
                    id => id.Value,
                    value => BetId.Of(value)
                );

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.GameId)
             .IsRequired();

            builder.Property(b => b.Amount)
              .IsRequired();

            builder.Property(b => b.Timestamp)
                   .IsRequired();
        }
    }
}
