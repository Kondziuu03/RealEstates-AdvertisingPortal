using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Common.Interfaces;

namespace RealEstates.Application.Announcements.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand>
{
    private readonly IApplicationDbContext _context;
    public DeleteAnnouncementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcementToDelete = await _context.Announcements
            .Include(x => x.Address)
            .Include(x => x.RealEstate)
            .Include(x => x.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        _context.Announcements.Remove(announcementToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
