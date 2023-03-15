using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Commands.AcceptAnnouncement;

public class AcceptAnnouncementCommandHandler : IRequestHandler<AcceptAnnouncementCommand>
{
    private readonly IApplicationDbContext _context;

    public AcceptAnnouncementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AcceptAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcementToAccept = _context.Announcements
            .Include(x => x.Address)
            .Include(x => x.RealEstate)
            .Include(x => x.Images)
            .FirstOrDefault(x => x.Id == request.Id);

        announcementToAccept.IsAccepted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
