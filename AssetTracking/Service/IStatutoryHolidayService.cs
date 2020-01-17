using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStatutoryHolidayService : IEntityService<StatutoryHoliday>
    {
        List<StatutoryHoliday> GetStatutoryHolidayByKey(string province);
        List<DateTime> GetCountedWorkingDays(DateTime startDate, int count);
    }
}
