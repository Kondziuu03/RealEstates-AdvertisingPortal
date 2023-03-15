using MediatR;
using RealEstates.Application.Announcements.Queries.GetAnnouncement;

namespace RealEstates.Application.Announcements.Queries.GetAnnouncementsToAccept;

public class GetAnnouncementsToAcceptQuery : IRequest<IEnumerable<AnnouncementDto>>
{
}
