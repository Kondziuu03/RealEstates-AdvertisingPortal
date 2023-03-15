using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstates.Application.Common.Interfaces;
using RealEstates.Domain.Entities;

namespace RealEstates.Application.Client.Commands;

public class AddAnnouncementToFavoriteCommandHandler : IRequestHandler<AddAnnouncementToFavoriteCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    public AddAnnouncementToFavoriteCommandHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(AddAnnouncementToFavoriteCommand request, CancellationToken cancellationToken)
    {

       

        return Unit.Value;
    }
}
