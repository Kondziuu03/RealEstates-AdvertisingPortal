
using Microsoft.AspNetCore.Identity;

namespace RealEstates.Domain.Entities;

public class ApplicationUser : IdentityUser
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegisterDateTime { get; set; }

    public bool isDeleted { get; set; }

    public ICollection<Announcement> Announcements { get; set; } = new HashSet<Announcement>();

}
