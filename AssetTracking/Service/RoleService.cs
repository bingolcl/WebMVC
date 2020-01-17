using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Data;
using Data;

namespace Service
{
    public class RoleService : EntityService<Role>, IRoleService
    {
        IDbContext _context;

        public RoleService(IDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
