using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.ActivityDtos
{
    public class UpdateActivityDto
    {
        public string? Comments { get; set; } = string.Empty;
        public DateTime? TimeStamp { get; set; }

        public int? TeacherId { get; set; }

        public int? StudentId { get; set; }

        public int? ActivityTypeId { get; set; }
    }
}
