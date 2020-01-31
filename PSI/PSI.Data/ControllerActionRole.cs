using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class ControllerActionRole
    {
        public int Id { get; set; }
        public int ControllerActionId { get; set; }
        public int RoleId { get; set; }
        public bool IsAllowed { get; set; }

        public virtual ControllerAction ControllerAction { get; set; }
    }
}
