using Core;
using Core.Helper;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StatutoryHolidayService : EntityService<StatutoryHoliday>, IStatutoryHolidayService
    {
        IDbContext _context;

        public StatutoryHolidayService(IDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<StatutoryHoliday> GetStatutoryHolidayByKey(string province)
        {
            return this.Entities.Where(s => s.IsActive && s.TaxableProvince == province).OrderBy(s => s.DateStamp).ToList();
        }

        public List<DateTime> GetCountedWorkingDays(DateTime startDate, int count)
        {
            List<DateTime> workingDays = new List<DateTime>();
            List<StatutoryHoliday> holidays = GetStatutoryHolidayByKey("BC");
            DateTime currentDay = startDate;
            int i = 0;

            while (i < count)
            {
                if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday && !holidays.Any(h => h.DateStamp == currentDay))
                {
                    workingDays.Add(currentDay);
                    currentDay = currentDay.AddDays(1);
                    i++;
                }
                else
                {
                    currentDay = currentDay.AddDays(1);
                }
            }

            return workingDays;
        }
    }
}
