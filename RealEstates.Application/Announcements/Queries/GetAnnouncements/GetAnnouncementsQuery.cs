using MediatR;
using RealEstates.Application.Announcements.Queries.GetAnnouncement;

namespace RealEstates.Application.Announcements.Queries.GetAnnouncements;

public class GetAnnouncementsQuery : IRequest<IEnumerable<AnnouncementDto>>
{
}
