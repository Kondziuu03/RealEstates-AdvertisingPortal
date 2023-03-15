using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Queries.GetAnnouncement;

public class GetAnnouncementQuery : IRequest<AnnouncementDto>
{
    public int Id { get; set; }
}
