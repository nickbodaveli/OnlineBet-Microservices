using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions.Abstractions;
using Hub.Domain.ValueObjects;

namespace Hub.Domain.Models
{
    public class Notification : Aggregate<NotificationId>
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
