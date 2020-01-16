using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IScheduleTaskService : IEntityService<ScheduleTask>
    {
        ScheduleTask GetTaskByType(string type);
    }
}
