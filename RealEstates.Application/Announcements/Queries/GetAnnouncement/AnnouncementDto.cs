using RealEstates.Domain.Entities;
using RealEstates.Domain.Enums;

namespace RealEstates.Application.Announcements.Queries.GetAnnouncement
{
    public class AnnouncementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivateAnnouncement { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsPromoted { get; set; }
        public int Likes { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public decimal Price { get; set; }
        public decimal Surface { get; set; }
        public int NumberOfRooms { get; set; }
        public int YearOfConstruction { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public RealEstateTypeEnum RealEstateTypeEnum { get; set; }
        public IEnumerable<string> ImagesUrl { get; set; } = new List<string>();

    }
}