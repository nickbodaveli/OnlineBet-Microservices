using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Hub.Domain.ValueObjects;

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

            builder.ComplexProperty(
              o => o.Amount, amountBuilder =>
              {
                  amountBuilder.Property(p => p.Amount)
                      .HasMaxLength(50);
              });

            builder.Property(b => b.Timestamp)
                   .IsRequired();
        }
    }
}
