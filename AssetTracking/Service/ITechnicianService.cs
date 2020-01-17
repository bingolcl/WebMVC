using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ITechnicianService : IEntityService<Technician>
    {
        Technician GetByEmployeeId(string company, string employeeId);
        int GetWorkingDays(int technicianId, DateTime ScheduleStartDate, DateTime ScheduleCompletionDate);
    }
}
