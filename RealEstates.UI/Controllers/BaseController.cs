using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Application.Common.Exceptions;
using RealEstates.UI.Models;
using System.Security.Claims;

namespace RealEstates.UI.Controllers;
public abstract class BaseController : Controller
{
    private ISender _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    protected string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

    protected async Task<MediatorValidateResponse<T>> MediatorSendValidate<T>(IRequest<T> request)
    {
        var response = new MediatorValidateResponse<T> { isValid = false };

        try
        {
            if (ModelState.IsValid)
            {
                response.Model = await Mediator.Send(request);
                response.isValid = true;
                return response;
            }
        }
        catch (ValidationException exception)
        {
            foreach (var item in exception.Errors)
            {
                ModelState.AddModelError(item.Key, string.Join(". ", item.Value));
            }
        }

        return response;
    }

}
