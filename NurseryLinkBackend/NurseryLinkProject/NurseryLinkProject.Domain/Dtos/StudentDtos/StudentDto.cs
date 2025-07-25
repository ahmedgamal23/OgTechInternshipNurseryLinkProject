using NurseryLinkProject.Domain.Dtos.UserDtos;
using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.StudentDtos
{
    public class StudentDto: UserDto
    {
        public Guid StudentCode { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int ClassId { get; set; } 
        public string ClassName { get; set; } = string.Empty;
        public int TeacherId { get; set; } 
        public string TeacherName { get; set; } = string.Empty;
    }
}
