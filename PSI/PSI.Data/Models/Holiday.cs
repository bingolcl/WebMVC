using System;
using System.Collections.Generic;

namespace PSI.Data.Models
{
    public partial class Holiday
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
