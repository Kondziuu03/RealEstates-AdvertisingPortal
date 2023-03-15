using Microsoft.EntityFrameworkCore;
using RealEstates.Domain.Entities;

namespace RealEstates.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Announcement> Announcements { get; set; }
        DbSet<RealEstate> RealEstates { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<SettingsPosition> SettingsPositions { get; set; }
        DbSet<RealEstates.Domain.Entities.Settings> Settings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
