using FluentValidation;
using Microsoft.AspNetCore.Http;
using RealEstates.Application.Common.Interfaces;

namespace RealEstates.Application.Announcements.Commands.EditAnnouncement;
public class EditAnnouncementCommandValidator : AbstractValidator<EditAnnouncementCommand>
{
    private readonly IApplicationDbContext _context;

    public EditAnnouncementCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleForEach(x => x.Files).SetValidator(new IFormValidator());
        RuleFor(x => x.Name).Must(ValidAnnouncementName).WithMessage("Istnieje ogłoszenie o podanej nazwie");
    }

    private bool ValidAnnouncementName(string Name)
    {
        if (_context.Announcements.Any(x => x.Name == Name)) return false;
        else return true;
    }
}

public class IFormValidator : AbstractValidator<IFormFile>
{
    private string[] _extensions = new string[3] { ".JPG", ".PNG", ".JPEG" };

    public IFormValidator()
    {
        RuleFor(x => x.Length)
            .LessThan(4000000).WithMessage("Wybrany plik jest zbyt duży");

        RuleFor(x => x.FileName)
            .Must(ValidName).WithMessage("Nieprawidłowa nazwa pliku")
            .Must(ValidExtensions).WithMessage("Nieprawidłowe rozszerzenie pliku")
            .Must(x => x.Length < 200).WithMessage("Zbyt długa nazwa pliku");
    }

    private bool ValidExtensions(string fileName)
    {
        var fileExtensions = Path.GetExtension(fileName).ToUpper();
        return _extensions.Contains(fileExtensions);
    }

    private bool ValidName(string fileName)
    {
        var dotCount = fileName.Where(x => x == '.').Count();

        if (dotCount > 1)
            return false;

        if (fileName.Contains("\\") || fileName.Contains("/") || fileName.Contains(":"))
            return false;

        return true;
    }
}
