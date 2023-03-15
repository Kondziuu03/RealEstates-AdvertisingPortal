using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Commands.LikeAnnouncementCommand;

public class LikeAnnouncementCommand : IRequest
{
    public int Id { get; set; }
}
