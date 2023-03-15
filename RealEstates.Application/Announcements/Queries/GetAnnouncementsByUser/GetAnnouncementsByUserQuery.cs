using MediatR;
using RealEstates.Application.Announcements.Queries.GetAnnouncement;

namespace RealEstates.Application.Announcements.Queries.GetAnnouncementsByUser;

public class GetAnnouncementsByUserQuery : IRequest<IEnumerable<AnnouncementDto>>
{
    public string UserId { get; set; }
}
