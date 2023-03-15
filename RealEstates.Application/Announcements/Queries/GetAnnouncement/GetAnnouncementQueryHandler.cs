using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Announcements.Extensions;
using RealEstates.Application.Common.Interfaces;

namespace RealEstates.Application.Announcements.Queries.GetAnnouncement;

public class GetAnnouncementQueryHandler : IRequestHandler<GetAnnouncementQuery, AnnouncementDto>
{
    private readonly IApplicationDbContext _context;

    public GetAnnouncementQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AnnouncementDto> Handle(GetAnnouncementQuery request, CancellationToken cancellationToken)
    {
        var announcement = await _context
            .Announcements
            .Include(x => x.Address)
            .Include(x => x.RealEstate)
            .Include(x => x.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return announcement.ToAnnouncementDto();
    }
}
