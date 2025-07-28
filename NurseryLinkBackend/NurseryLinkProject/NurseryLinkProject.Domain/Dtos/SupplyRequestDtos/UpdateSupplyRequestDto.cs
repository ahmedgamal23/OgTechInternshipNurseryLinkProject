using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.SupplyRequestDtos
{
    public class UpdateSupplyRequestDto: UpdateActivityDto
    {
        public string? Message { get; set; } 
        public string? Item { get; set; }
        public SupplyRequestStatus? Status { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
