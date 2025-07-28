using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }

        public int TeacherId { get; set; }  // FK
        public User Teacher { get; set; } = default!; // Navigation property

        public int StudentId { get; set; }  // FK
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Student Student { get; set; } = default!; // Navigation property

        public int ActivityTypeId { get; set; }  // FK
        public ActivityType ActivityType { get; set; } = default!; // Navigation property
    }
}
