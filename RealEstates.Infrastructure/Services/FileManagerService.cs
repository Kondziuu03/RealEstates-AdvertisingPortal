using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RealEstates.Application.Common.Interfaces;
using RealEstates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Infrastructure.Services;

public class FileManagerService : IFileManagerService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileManagerService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public List<Image> ConvertToImages(IEnumerable<IFormFile> files)
    {
        var images = new List<Image>();

        foreach (var file in files)
        {
            var image = new Image
            {
                Name = file.FileName,
                Bytes = file.Length
            };

            images.Add(image);
        }

        return images;
    }

    public async Task Upload(IEnumerable<IFormFile> files, string announcementName)
    {
        var folderRoot = Path.Combine(_webHostEnvironment.WebRootPath, "Content", "Files", announcementName);

        if (!Directory.Exists(folderRoot))
            Directory.CreateDirectory(folderRoot);

        if (files == null || !files.Any())
            return;

        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine(folderRoot, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
    }

    public void DeleteFiles(string announcementName)
    {
        var folderRoot = Path.Combine(_webHostEnvironment.WebRootPath, "Content", "Files", announcementName);
        Directory.Delete(folderRoot, true);
    }

}
