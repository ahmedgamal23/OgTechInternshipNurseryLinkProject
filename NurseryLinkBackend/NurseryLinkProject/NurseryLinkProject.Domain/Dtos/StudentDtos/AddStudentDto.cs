using NurseryLinkProject.Domain.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.StudentDtos
{
    public class AddStudentDto: AddUserDto
    {
        public Guid StudentCode { get; set; } = Guid.NewGuid();
        public DateOnly DateOfBirth { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
    }
}
