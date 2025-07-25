using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.ParentStudentDtos
{
    public class AddParentStudentDto
    {
        public int ParentId { get; set; } 
        public int StudentId { get; set; } 
    }
}
