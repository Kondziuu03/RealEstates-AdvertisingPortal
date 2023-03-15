using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Common.Interfaces;

namespace RealEstates.Application.Announcements.Commands.LikeAnnouncementCommand;

public class LikeAnnouncementCommandHandler : IRequestHandler<LikeAnnouncementCommand>
{
    private readonly IApplicationDbContext _context;

    public LikeAnnouncementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(LikeAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcementToChange = await _context.Announcements
            .FirstOrDefaultAsync(a => a.Id == request.Id);

        announcementToChange.Likes += 1;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
