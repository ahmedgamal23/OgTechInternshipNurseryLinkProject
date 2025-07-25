using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class Student : User
    {
        public Guid StudentCode { get; set; } = Guid.NewGuid();
        public DateOnly DateOfBirth { get; set; }
        public int ClassId { get; set; }  // FK
        public NurseryClass NurseryClass { get; set; } = default!; // Navigation property
    }
}
