
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Domain.Entities;

namespace RealEstates.Infrastructure.Persistence.Configurations;

class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(20000);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder
            .HasOne(x => x.RealEstate)
            .WithOne(x => x.Announcement)
            .HasForeignKey<RealEstate>(x => x.AnnouncementId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Address)
            .WithOne(x => x.Announcement)
            .HasForeignKey<Address>(x => x.AnnouncementId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Announcements)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
