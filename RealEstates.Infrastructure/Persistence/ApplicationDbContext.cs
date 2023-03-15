using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Common.Interfaces;
using RealEstates.Domain.Entities;
using RealEstates.Infrastructure.Persistence.Extensions;
using System.Reflection;

namespace RealEstates.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)   { }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<RealEstate> RealEstates { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<SettingsPosition> SettingsPositions { get; set; }
    public DbSet<Settings> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.SeedRoles();
        modelBuilder.SeedSettings();
        modelBuilder.SeedSettingsPosition();

        base.OnModelCreating(modelBuilder);
    }
}
