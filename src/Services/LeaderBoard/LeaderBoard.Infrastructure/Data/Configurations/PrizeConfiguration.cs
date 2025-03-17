using LeaderBoard.Domain.Models;
using LeaderBoard.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaderBoard.Infrastructure.Data.Configurations
{
    public class PrizeConfiguration : IEntityTypeConfiguration<Prize>
    {
        public void Configure(EntityTypeBuilder<Prize> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasConversion(
                    id => id.Value,
                    value => PrizeId.Of(value)
                );

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.LeaderBoardId)
                .IsRequired()
                .HasConversion( 
                    id => id.Value,
                    value => LeaderBoardId.Of(value)
                );

            builder.HasOne<Domain.Models.LeaderBoard>() 
                .WithMany()
                .HasForeignKey(b => b.LeaderBoardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.Name)
                .IsRequired();
        }
    }
}
