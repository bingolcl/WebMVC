﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ControllerActionRoleService : EntityService<ControllerActionRole>, IControllerActionRoleService
    {
        IDbContext _context;

        public ControllerActionRoleService(IDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
