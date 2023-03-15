using RealEstates.Domain.Enums;

namespace RealEstates.Domain.Entities
{
    public class RealEstate
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Surface { get; set; }
        public int NumberOfRooms { get; set; }
        public int YearOfConstruction { get; set; }
        public RealEstateTypeEnum RealEstateTypeEnum { get; set; }
        public int AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
    }
}