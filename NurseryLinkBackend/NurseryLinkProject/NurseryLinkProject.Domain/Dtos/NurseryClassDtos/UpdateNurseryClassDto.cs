using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.NurseryClassDtos
{
    public class UpdateNurseryClassDto
    {
        public string? ClassName { get; set; } 
        public int? TeacherId { get; set; }
    }
}
