using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Application.Announcements.Queries.GetAnnouncements;
using RealEstates.Application.Announcements.Queries.GetAnnouncementsToAccept;
using RealEstates.Application.Dictionaries;

namespace RealEstates.UI.Controllers
{
    [Authorize(Roles = RolesDict.Administrator)]
    public class AdminController : BaseController
    {
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.ShowButtonToAccept = false;
            return View(await Mediator.Send(new GetAnnouncementsQuery()));
        }
        public async Task<IActionResult> Announcements()
        {
            ViewBag.ShowButtonToAccept = true;
            return View(await Mediator.Send(new GetAnnouncementsToAcceptQuery()));
        }
    }
}
