
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Domain.Entities;

namespace RealEstates.Infrastructure.Persistence.Configurations;

class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(300);


        builder
            .HasOne(x => x.Announcement)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.AnnouncementId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}
