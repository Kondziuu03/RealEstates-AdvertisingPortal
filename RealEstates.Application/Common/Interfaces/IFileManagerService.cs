using Microsoft.AspNetCore.Http;
using RealEstates.Domain.Entities;

namespace RealEstates.Application.Common.Interfaces;
public interface IFileManagerService
{
    Task Upload(IEnumerable<IFormFile> files, string announcementName);
    public List<Image> ConvertToImages(IEnumerable<IFormFile> files);
    void DeleteFiles(string name);
}
