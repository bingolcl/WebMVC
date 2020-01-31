using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class Submission
    {
        public int Id { get; set; }
        public string TechnicianId { get; set; }
        public string Ccemail { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public DateTime SubmittedDateTime { get; set; }
        public int TimeZoneOffset { get; set; }
    }
}
