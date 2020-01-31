using System;
using System.Collections.Generic;

namespace PSI.Data.Models
{
    public partial class WorkingAlone
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string MergencyContactName { get; set; }
        public string MergencyContactPhone { get; set; }
        public bool? DrivingAlone { get; set; }
        public bool? FallRestraint { get; set; }
        public bool? EnergizedWork { get; set; }
        public bool? WorkOffLadders { get; set; }
    }
}
