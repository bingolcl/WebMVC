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
    public class TechnicianService : EntityService<Technician>, ITechnicianService
    {
        IDbContext _context;
        IStatutoryHolidayService _statutoryHolidayService;

        public TechnicianService(IDbContext context,
                                 IStatutoryHolidayService statutoryHolidayService)
            : base(context)
        {
            _context = context;
            _statutoryHolidayService = statutoryHolidayService;
        }

        public int GetWorkingDays(int technicianId, DateTime ScheduleStartDate, DateTime ScheduleCompletionDate)
        {
            var technician = this.Entities.Single(t => t.Id == technicianId);

            List<DateTime> blackOutDates = new List<DateTime>();
            foreach (var blackOut in technician.Blackouts)
            {
                for (DateTime date = blackOut.StartDate; date <= blackOut.EndDate; date = date.AddDays(1))
                    blackOutDates.Add(date);
            }

            List<StatutoryHoliday> holidays = _statutoryHolidayService.GetStatutoryHolidayByKey("BC");

            DateTime startDate = ScheduleStartDate > DateTime.Today ? ScheduleStartDate : DateTime.Today;
            DateTime completionDate = ScheduleCompletionDate;

            //http://stackoverflow.com/questions/1617049/calculate-the-number-of-business-days-between-two-dates
            //http://stackoverflow.com/questions/1820173/calculate-the-number-of-weekdays-between-two-dates-in-c-sharp           
            int firstDay = ((int)startDate.DayOfWeek == 0 ? 7 : (int)startDate.DayOfWeek);
            int lastDay = ((int)completionDate.DayOfWeek == 0 ? 7 : (int)completionDate.DayOfWeek);
            TimeSpan span = completionDate - startDate;
            if (firstDay <= lastDay)
            {
                return (((span.Days / 7) * 5) + Math.Max((Math.Min((lastDay + 1), 6) - firstDay), 0));
            }

            int workingDays = (((span.Days / 7) * 5) + Math.Min((lastDay + 6) - Math.Min(firstDay, 6), 5));

            //Remove holidays
            foreach (StatutoryHoliday holiday in holidays)
            {
                DateTime h = holiday.DateStamp;
                if (startDate <= h && h <= completionDate)
                {
                    --workingDays;
                }
            }

            //Remove balckout dates
            foreach (DateTime item in blackOutDates)
            {
                if (startDate <= item && item <= completionDate)
                {
                    --workingDays;
                }
            }

            return workingDays;
        }

        public Technician GetByEmployeeId(string company, string employeeId)
        {
            return this.Entities.FirstOrDefault(u => u.Company == company && u.EmployeeId == employeeId);
        }
    }
}
