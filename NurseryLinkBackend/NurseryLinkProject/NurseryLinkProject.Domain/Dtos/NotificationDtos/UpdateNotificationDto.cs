using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public string? Message { get; set; }
        public NotificationType? Type { get; set; }
        public bool? IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? StudentId { get; set; }
        public int? ParentId { get; set; }
    }
}
