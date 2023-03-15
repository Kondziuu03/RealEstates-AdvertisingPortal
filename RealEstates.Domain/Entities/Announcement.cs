
namespace RealEstates.Domain.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public bool IsPrivateAnnouncement { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsPromoted { get; set; }
        public bool IsEnded { get; set; }
        public int Likes { get; set; }
        public RealEstate RealEstate { get; set; }
        public Address Address { get; set; }
        public ICollection<Image> Images { get; set; } = new HashSet<Image>();
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}