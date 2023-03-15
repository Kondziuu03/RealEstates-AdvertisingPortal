using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Announcements.Commands.EditAnnouncement;
using RealEstates.Application.Announcements.Extensions;
using RealEstates.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Queries.GetEditAnnouncementQuery;

public class GetEditAnnouncementQueryHandler : IRequestHandler<GetEditAnnouncementQuery, EditAnnouncementCommand>
{
    private readonly IApplicationDbContext _context;
    public GetEditAnnouncementQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EditAnnouncementCommand> Handle(GetEditAnnouncementQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Announcements
            .Include(x => x.Address)
            .Include(x => x.RealEstate)
            .Include(x => x.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(x=> x.Id == request.Id))
            .ToEditAnnouncementCommand();
    }
}
