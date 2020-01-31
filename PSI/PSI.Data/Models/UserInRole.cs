﻿using System;
using System.Collections.Generic;

namespace PSI.Data.Models
{
    public partial class UserInRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
