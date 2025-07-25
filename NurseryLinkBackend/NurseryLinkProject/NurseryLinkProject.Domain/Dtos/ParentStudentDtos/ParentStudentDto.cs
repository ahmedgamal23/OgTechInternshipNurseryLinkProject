using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.ParentStudentDtos
{
    public class ParentStudentDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; } = string.Empty;
        public string ParentEmail { get; set; } = string.Empty;
        public string ParentPhoneNumber { get; set; } = string.Empty;

        public int StudentId { get; set; }  
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentPhoneNumber { get; set; } = string.Empty;
        public Guid StudentCode { get; set; } 
    }
}
