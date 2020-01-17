using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ControllerActionService : EntityService<ControllerAction>, IControllerActionService
    {
        IDbContext _context;

        public ControllerActionService(IDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
