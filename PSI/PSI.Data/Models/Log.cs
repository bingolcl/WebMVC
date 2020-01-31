using System;
using System.Collections.Generic;

namespace PSI.Data.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public int LogLevelId { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public string IpAddress { get; set; }
        public string PageUrl { get; set; }
        public string ReferrerUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
        public string StackTrace { get; set; }
    }
}
