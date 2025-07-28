using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class NurseryClass
    {
        public int Id { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int TeacherId { get; set; }  // FK
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public User Teacher { get; set; } = default!; // Navigation property
    }
}
