using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Application.Announcements.Queries.GetAnnouncementsByUser;

namespace RealEstates.UI.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        public async Task<IActionResult> Dashboard()
        {
            return View(await Mediator.Send(new GetAnnouncementsByUserQuery { UserId = UserId}));
        }
    }
}
