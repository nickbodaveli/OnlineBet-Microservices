using LeaderBoard.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
