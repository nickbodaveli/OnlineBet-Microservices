using Hub.Domain.Models;
using Hub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hub.Infrastructure.Data.Configurations
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

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.Amount)
              .IsRequired();

            builder.Property(b => b.Timestamp)
                   .IsRequired();
        }
    }
}
