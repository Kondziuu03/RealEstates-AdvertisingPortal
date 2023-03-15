
namespace RealEstates.Domain.Entities;

public class Image
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Bytes { get; set; }

    public int AnnouncementId { get; set; }
    public Announcement Announcement { get; set; }
}
