using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.ToiletDtos
{
    public class UpdateToiletDto : UpdateActivityDto
    {
        public VisitType? VisitType { get; set; }
    }
}
