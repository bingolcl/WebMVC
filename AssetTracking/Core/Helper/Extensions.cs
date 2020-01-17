using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class Extensions
    {
        public static int GetWeekNumberOfMonth(this DateTime date)
        {
            return GetWeekNumberOfMonth(date, CultureInfo.CurrentCulture);
        }

        public static int GetWeekNumberOfMonth(this DateTime date, CultureInfo culture)
        {
            return date.GetWeekNumber(culture)
                 - new DateTime(date.Year, date.Month, 1).GetWeekNumber(culture)
                 + 1; // Or skip +1 if you want the first week to be 0.
        }

        public static int GetWeekNumber(this DateTime date)
        {
            return GetWeekNumber(date, CultureInfo.CurrentCulture);
        }

        public static int GetWeekNumber(this DateTime date, CultureInfo culture)
        {
            return culture.Calendar.GetWeekOfYear(date,
                culture.DateTimeFormat.CalendarWeekRule,
                culture.DateTimeFormat.FirstDayOfWeek);
        }
    }
}
