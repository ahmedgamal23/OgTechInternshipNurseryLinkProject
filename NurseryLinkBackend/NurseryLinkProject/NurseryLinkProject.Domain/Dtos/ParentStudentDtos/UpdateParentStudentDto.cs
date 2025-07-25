using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.ParentStudentDtos
{
    public class UpdateParentStudentDto
    {
        public int? ParentId { get; set; }  
        public int? StudentId { get; set; }  
    }
}
