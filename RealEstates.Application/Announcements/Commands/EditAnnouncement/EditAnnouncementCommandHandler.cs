using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Common.Interfaces;

namespace RealEstates.Application.Announcements.Commands.EditAnnouncement;

public class EditAnnouncementCommandHandler : IRequestHandler<EditAnnouncementCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly IFileManagerService _fileManagerService;

    public EditAnnouncementCommandHandler(IApplicationDbContext context,
        IDateTimeService dateTimeService,
        IFileManagerService fileManagerService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _fileManagerService = fileManagerService;
    }

    public async Task<Unit> Handle(EditAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await _context.Announcements
            .Include(x => x.Address)
            .Include(x => x.RealEstate)
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (request.Files != null)
        {
            _fileManagerService.DeleteFiles(announcement.Name);
            var images = _fileManagerService.ConvertToImages(request.Files);
            announcement.Images = images;
            await _fileManagerService.Upload(request.Files, request.Name);
        }

        announcement.Name = request.Name;
        announcement.IsPrivateAnnouncement = request.IsPrivateAnnouncement;
        announcement.DateOfUpdate = _dateTimeService.Now;
        announcement.Address.City = request.City;
        announcement.Address.Street = request.Street;
        announcement.Address.StreetNumber = request.StreetNumber;
        announcement.Address.ZipCode = request.ZipCode;
        announcement.Address.Country = request.Country;
        announcement.RealEstate.Surface = request.Surface;
        announcement.RealEstate.YearOfConstruction = request.YearOfConstruction;
        announcement.RealEstate.Price = request.Price;
        announcement.RealEstate.NumberOfRooms = request.NumberOfRooms;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;

    }
}
