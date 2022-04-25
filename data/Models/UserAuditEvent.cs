using System;
using System.Collections.Generic;

#nullable disable

namespace Curate.Data.Models
{
    public partial class UserAuditEvent
    {
        public int UserAuditId { get; set; }
        public int AuditEvent { get; set; }
        public string IpAddress { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string UserId { get; set; }
    }
}
