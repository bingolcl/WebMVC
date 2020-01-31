using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class Holiday
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
