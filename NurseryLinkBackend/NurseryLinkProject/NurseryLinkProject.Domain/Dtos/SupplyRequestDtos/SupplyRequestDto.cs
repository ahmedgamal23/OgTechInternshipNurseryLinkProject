using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.SupplyRequestDtos
{
    public class SupplyRequestDto: ActivityDto
    {
        public string Message { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public SupplyRequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
