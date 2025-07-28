using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class ParentStudent
    {
        public int Id { get; set; }
        public int ParentId { get; set; }   // FK
        public User Parent { get; set; } = default!; // Navigation property

        public int StudentId { get; set; }  // FK
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Student Student { get; set; } = default!; // Navigation property
    }
}
