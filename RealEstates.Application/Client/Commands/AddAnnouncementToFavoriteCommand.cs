using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Client.Commands;

public class AddAnnouncementToFavoriteCommand : IRequest
{
    public int Id { get; set; }
    public string UserId { get; set; }
}
