using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Commands.AcceptAnnouncement;

public class AcceptAnnouncementCommand : IRequest
{
    public int Id { get; set; }
}
