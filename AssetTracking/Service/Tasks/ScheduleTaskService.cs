using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ScheduleTaskService : EntityService<ScheduleTask>, IScheduleTaskService
    {
        IDbContext _context;

        public ScheduleTaskService(IDbContext context)
            : base(context)
        {
            _context = context;
        }


        public ScheduleTask GetTaskByType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return null;

            return this.Entities.FirstOrDefault(t => t.Type == type);
        }
    }
}
