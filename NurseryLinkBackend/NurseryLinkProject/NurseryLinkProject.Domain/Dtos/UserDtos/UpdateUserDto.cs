using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public string? FullName { get; set; } 
        public string? Username { get; set; } 
        public string? Email { get; set; }
        public string? Password { get; set; } 
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } 
        public DateTime UpdateAt { get; set; }
        public int RoleId { get; set; }  
    }
}
