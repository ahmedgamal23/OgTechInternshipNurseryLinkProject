using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.ActivityDtos
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }

        public int TeacherId { get; set; } 
        public string TeacherName { get; set; } = string.Empty;
        public string TeacherEmail { get; set; } = string.Empty;
        public string TeacherPhoneNumber { get; set; } = string.Empty;

        public int StudentId { get; set; }  
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public Guid StudentCode { get; set; }

        public int ActivityTypeId { get; set; }  
        public string ActivityTypeName { get; set; } = string.Empty;
    }
}
