using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Application.Announcements.Commands.AcceptAnnouncement;
using RealEstates.Application.Announcements.Commands.AddAnnouncement;
using RealEstates.Application.Announcements.Commands.DeleteAnnouncement;
using RealEstates.Application.Announcements.Commands.EditAnnouncement;
using RealEstates.Application.Announcements.Commands.LikeAnnouncementCommand;
using RealEstates.Application.Announcements.Queries.GetAnnouncement;
using RealEstates.Application.Announcements.Queries.GetAnnouncements;
using RealEstates.Application.Announcements.Queries.GetEditAnnouncementQuery;
using RealEstates.Application.Common.Exceptions;

namespace RealEstates.UI.Controllers
{
    [Authorize]
    public class AnnouncementController : BaseController
    {
        private readonly ILogger<AnnouncementController> _logger;

        public AnnouncementController(ILogger<AnnouncementController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Announcement(int id)
        {
            return View(await Mediator.Send(new GetAnnouncementQuery { Id = id }));          
        }

        public async Task<IActionResult> Announcements()
        {
            return View(await Mediator.Send(new GetAnnouncementsQuery()));
        }

        public async Task<IActionResult> AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(AddAnnouncementCommand command)
        {

            try
            {
                command.UserId = UserId;
                await Mediator.Send(command);

                TempData["Success"] = "Ogłoszenie zostało wysłane do akceptacji";

                return RedirectToAction("Index", "Home");
            }
            catch (ValidationException exception)
            {
                TempData["Error"] = string.Join(". ", exception.Errors.Select(x => string.Join(". ", x.Value.Select(y => y))));

                return View();
            }
            catch (Exception exception)
            {
                TempData["Error"] = "Wystąpił błąd przy wysyłaniu formularza";

                return View();
            }
        }

        public async Task<IActionResult> EditAnnouncement(int id)
        {
            return View(await Mediator.Send(new GetEditAnnouncementQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnnouncement(EditAnnouncementCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.isValid)
                return View(command);

            TempData["Success"] = "Twoje ogłoszenie zostało zaktualizowane";

            return RedirectToAction("Dashboard", "Client");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            try
            {
                await Mediator.Send(new DeleteAnnouncementCommand { Id = id });

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AcceptAnnouncement(int id)
        {
            try
            {
                await Mediator.Send(new AcceptAnnouncementCommand { Id = id });

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> LikeAnnouncement(int id)
        {
            try
            {
                await Mediator.Send(new LikeAnnouncementCommand { Id = id });

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                return Json(new { success = false });
            }
        }
    }
}
