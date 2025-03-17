using Hub.Domain.Models;
using Hub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hub.Infrastructure.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasConversion(
                    id => id.Value,
                    value => NotificationId.Of(value)
                );

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.Message)
              .IsRequired();


            builder.Property(b => b.IsRead)
              .IsRequired();

            builder.Property(b => b.Timestamp)
                   .IsRequired();
        }
    }
}
