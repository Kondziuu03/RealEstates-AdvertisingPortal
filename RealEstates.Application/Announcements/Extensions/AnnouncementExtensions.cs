using RealEstates.Application.Announcements.Commands.EditAnnouncement;
using RealEstates.Application.Announcements.Queries.GetAnnouncement;
using RealEstates.Domain.Entities;
using RealEstates.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Extensions;

public static class AnnouncementExtensions
{
    public static AnnouncementDto ToAnnouncementDto(this Announcement announcement)
    {
        if (announcement == null)
            return null;

        var imagesUrl = new List<string>();

        foreach(var image in announcement.Images)
        {
            var imageUrl = $"/Content/Files/{announcement.Name}/{image.Name}";
            imagesUrl.Add(imageUrl);
        }

        return new AnnouncementDto { 
            Id = announcement.Id,
            Name = announcement.Name,
            Description = announcement.Description,
            IsPrivateAnnouncement = announcement.IsPrivateAnnouncement,
            IsAccepted = announcement.IsAccepted,
            IsPromoted = announcement.IsPromoted,
            Likes = announcement.Likes,
            Country = announcement.Address.Country,
            City = announcement.Address.City,
            Street = announcement.Address.Street,
            StreetNumber = announcement.Address.StreetNumber,
            ZipCode = announcement.Address.ZipCode,
            Price = announcement.RealEstate.Price,
            Surface = announcement.RealEstate.Surface,
            NumberOfRooms = announcement.RealEstate.NumberOfRooms,
            YearOfConstruction = announcement.RealEstate.YearOfConstruction,
            DateOfCreate = announcement.DateOfCreate,
            DateOfUpdate = announcement.DateOfUpdate,
            RealEstateTypeEnum = announcement.RealEstate.RealEstateTypeEnum,
            ImagesUrl = imagesUrl
        };

    }

    public static EditAnnouncementCommand ToEditAnnouncementCommand(this Announcement announcement)
    {
        if (announcement == null)
            return null;

        return new EditAnnouncementCommand
        {
            Id = announcement.Id,
            Name = announcement.Name,
            Description = announcement.Description,
            IsPrivateAnnouncement = announcement.IsPrivateAnnouncement,
            Country = announcement.Address.Country,
            City = announcement.Address.City,
            Street = announcement.Address.Street,
            StreetNumber = announcement.Address.StreetNumber,
            ZipCode = announcement.Address.ZipCode,
            Price = announcement.RealEstate.Price,
            Surface = announcement.RealEstate.Surface,
            NumberOfRooms = announcement.RealEstate.NumberOfRooms,
            YearOfConstruction = announcement.RealEstate.YearOfConstruction
        };

    }

}
