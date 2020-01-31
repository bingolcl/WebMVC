using System;
using System.Collections.Generic;

namespace PSI.Data
{
    public partial class ControllerAction
    {
        public ControllerAction()
        {
            ControllerActionRole = new HashSet<ControllerActionRole>();
        }

        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsController { get; set; }
        public bool IsAllowedNonRoles { get; set; }
        public bool IsAllowedAllRoles { get; set; }

        public virtual ICollection<ControllerActionRole> ControllerActionRole { get; set; }
    }
}
