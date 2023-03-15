

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RealEstates.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensionsRoles
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "E673A36A-9310-49CA-B64D-B89F1D54FEE3",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "6361294E-A052-4851-A4A4-A1031CFBBD92"
            },
            new IdentityRole
            {
                Id = "75EAFA86-47E4-4EAB-9833-5181E2F56943",
                Name = "Użytkownik",
                NormalizedName = "UŻYTKOWNIK",
                ConcurrencyStamp = "6FAEB7FB-C5CF-4A59-9C83-D2C4FD7F84CF"
            }
            );
    }
}
