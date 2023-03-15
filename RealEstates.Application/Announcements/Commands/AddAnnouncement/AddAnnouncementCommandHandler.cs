using MediatR;
using RealEstates.Application.Common.Interfaces;
using RealEstates.Domain.Entities;

namespace RealEstates.Application.Announcements.Commands.AddAnnouncement;

public class AddAnnouncementCommandHandler : IRequestHandler<AddAnnouncementCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly IFileManagerService _fileManagerService;

    public AddAnnouncementCommandHandler(IApplicationDbContext context,
        IDateTimeService dateTimeService,
        IFileManagerService fileManagerService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _fileManagerService = fileManagerService;
    }
    public async Task<Unit> Handle(AddAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var address = new Address
        {
            Country = request.Country,
            City = request.City,
            Street = request.Street,
            StreetNumber = request.StreetNumber,
            ZipCode = request.ZipCode
        };

        var realEstate = new RealEstate 
        {
            Price = request.Price,
            Surface = request.Surface,
            YearOfConstruction = request.YearOfConstruction,
            NumberOfRooms = request.NumberOfRooms,
            RealEstateTypeEnum = Domain.Enums.RealEstateTypeEnum.Flat,
            
        };

        var images = _fileManagerService.ConvertToImages(request.Files);

        var announcement = new Announcement
        {
            UserId = request.UserId,
            Name = request.Name,
            Description = request.Description,
            DateOfCreate = _dateTimeService.Now,
            DateOfUpdate = _dateTimeService.Now,
            IsPrivateAnnouncement = request.IsPrivateAnnouncement,
            IsAccepted = false,
            IsEnded = false,
            IsPromoted = false,
            Images = images,
            RealEstate = realEstate,
            Address = address
        };

        await _fileManagerService.Upload(request.Files, request.Name);

        _context.Announcements.Add(announcement);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
