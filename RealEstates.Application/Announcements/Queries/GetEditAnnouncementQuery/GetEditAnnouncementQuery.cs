using MediatR;
using RealEstates.Application.Announcements.Commands.EditAnnouncement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Queries.GetEditAnnouncementQuery;

public class GetEditAnnouncementQuery : IRequest<EditAnnouncementCommand>
{
    public int Id { get; set; }
}
