using Microsoft.AspNetCore.Mvc;
using RealEstates.Application.Announcements.Queries.GetAnnouncements;

namespace RealEstates.UI.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}