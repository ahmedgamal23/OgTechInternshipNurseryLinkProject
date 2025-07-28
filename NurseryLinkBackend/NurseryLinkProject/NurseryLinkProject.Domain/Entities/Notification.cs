using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; }

        public int StudentId { get; set; }  // FK
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Student Student { get; set; } = default!; // Navigation property
        public int ParentId { get; set; }   // FK
        public User Parent { get; set; } = default!; // Navigation property
    }

    public enum NotificationType
    {
        ActivityUpdate,
        ClassAnnouncement,
        GeneralNotification,
        SupplyRequestUpdate,
        Other
    }

}
