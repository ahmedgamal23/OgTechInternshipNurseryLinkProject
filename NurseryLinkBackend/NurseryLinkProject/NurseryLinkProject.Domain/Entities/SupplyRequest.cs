using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class SupplyRequest: Activity
    {
        public string Message { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public SupplyRequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
    }

    public enum SupplyRequestStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }
}
