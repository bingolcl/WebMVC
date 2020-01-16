using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ActivityLogTypeService : EntityService<ActivityLogType>, IActivityLogTypeService
    {
        IDbContext _context;

        public ActivityLogTypeService(IDbContext context)
            : base(context)
        {
            _context = context;
        }        
    }
}
