using RealEstates.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealEstates.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsSettings
{
    public static void SeedSettings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Settings>().HasData(
            new Settings
            {
                Id = 1,
                Description = "E-mail",
                Order = 2
            });
    }
}