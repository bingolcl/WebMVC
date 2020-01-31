using System;
using System.Collections.Generic;

namespace PSI.Data.Models
{
    public partial class ActivityLog
    {
        public int Id { get; set; }
        public int ActivityLogTypeId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ActivityLogType ActivityLogType { get; set; }
    }
}
