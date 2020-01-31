using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class Psi
    {
        public int Id { get; set; }
        public bool? Scope { get; set; }
        public bool? EvacuationPlan { get; set; }
        public bool? Ppe { get; set; }
        public bool? HighVisVest { get; set; }
        public bool? Gloves { get; set; }
        public bool? HardHat { get; set; }
        public bool? HearingProtection { get; set; }
        public bool? SafetyFootwear { get; set; }
        public bool? SafetyEyewear { get; set; }
        public bool? Respirator { get; set; }
        public bool? EnergizedWorkPpe { get; set; }
        public bool? LockoutRequired { get; set; }
        public bool? EnergizedWorkRequired { get; set; }
        public bool? TaskAbove { get; set; }
        public bool? LiftingOver { get; set; }
        public bool? TripHazards { get; set; }
        public bool? HeatStress { get; set; }
        public bool? ColdStress { get; set; }
        public bool? OtherTrades { get; set; }
        public bool? Chemical { get; set; }
        public bool? StepLadder { get; set; }
        public bool? ExtensionLadder { get; set; }
        public string OtherHazards { get; set; }
    }
}
