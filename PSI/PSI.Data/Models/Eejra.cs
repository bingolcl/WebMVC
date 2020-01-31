using System;
using System.Collections.Generic;

namespace PSI.Data.Models
{
    public partial class Eejra
    {
        public int Id { get; set; }
        public bool? Healthy { get; set; }
        public bool? ShockHazard { get; set; }
        public string ArcFlashExemptions { get; set; }
        public bool? ElectricalSafe { get; set; }
        public bool? RubberGloves { get; set; }
        public bool? EquipmentMaintained { get; set; }
        public bool? NoImpendingFailure { get; set; }
        public bool? DoorsSecured { get; set; }
        public bool? HighRisk { get; set; }
    }
}
