
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Domain.Entities;

namespace RealEstates.Infrastructure.Persistence.Configurations;

class RealEstateConfiguration : IEntityTypeConfiguration<RealEstate>
{
    public void Configure(EntityTypeBuilder<RealEstate> builder)
    {
        builder.ToTable("RealEstates");

        builder.Property(x => x.AnnouncementId)
            .IsRequired();


    }
}
