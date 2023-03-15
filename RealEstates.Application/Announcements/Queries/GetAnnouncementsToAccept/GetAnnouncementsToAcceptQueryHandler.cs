using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Announcements.Extensions;
using RealEstates.Application.Announcements.Queries.GetAnnouncement;
using RealEstates.Application.Common.Interfaces;

namespace RealEstates.Application.Announcements.Queries.GetAnnouncementsToAccept;

public class GetAnnouncementsToAcceptQueryHandler : IRequestHandler<GetAnnouncementsToAcceptQuery, IEnumerable<AnnouncementDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAnnouncementsToAcceptQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<AnnouncementDto>> Handle(GetAnnouncementsToAcceptQuery request, CancellationToken cancellationToken)
    {
        return await _context.Announcements
           .Include(x => x.Address)
           .Include(x => x.RealEstate)
           .Include(x => x.Images)
           .AsNoTracking()
           .Where(x => x.IsAccepted == false)
           .Select(x => x.ToAnnouncementDto())
           .ToListAsync();
    }
}
