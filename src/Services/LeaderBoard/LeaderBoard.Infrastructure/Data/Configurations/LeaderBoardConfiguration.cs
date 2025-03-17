using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LeaderBoard.Domain.ValueObjects;

namespace LeaderBoard.Infrastructure.Data.Configurations
{
    public class LeaderBoardConfiguration : IEntityTypeConfiguration<Domain.Models.LeaderBoard>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.LeaderBoard> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasConversion(
                    id => id.Value,
                    value => LeaderBoardId.Of(value)
                );

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.GameId)
             .IsRequired();
        }
    }
}
