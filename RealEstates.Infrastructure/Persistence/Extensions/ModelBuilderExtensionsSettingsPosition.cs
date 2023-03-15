using RealEstates.Application.Dictionaries;
using RealEstates.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealEstates.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsSettingsPosition
{
    public static void SeedSettingsPosition(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SettingsPosition>().HasData(
            new SettingsPosition
            {
                Id = 1,
                Key = SettingsDict.HostSmtp,
                Value = "smtp.gmail.com",
                Description = "Host",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 1
            },
            new SettingsPosition
            {
                Id = 2,
                Key = SettingsDict.Port,
                Value = "587",
                Description = "Port",
                Type = Domain.Enums.SettingsType.Integer,
                SettingsId = 1,
                Order = 2
            },
            new SettingsPosition
            {
                Id = 3,
                Key = SettingsDict.SenderEmail,
                Value = "",
                Description = "Adres e-mail nadawcy",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 3
            },
            new SettingsPosition
            {
                Id = 4,
                Key = SettingsDict.SenderEmailPassword,
                Value = "",
                Description = "Hasło",
                Type = Domain.Enums.SettingsType.Password,
                SettingsId = 1,
                Order = 4
            },
            new SettingsPosition
            {
                Id = 5,
                Key = SettingsDict.SenderName,
                Value = "Konrad Kolka",
                Description = "Nazwa nadawcy",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 5
            },
            new SettingsPosition
            {
                Id = 6,
                Key = SettingsDict.SenderLogin,
                Value = "",
                Description = "Login nadawcy",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 6
            });
    }
}