using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertDengueApi.Interfaces;

namespace AlertDengueApi.Helpers
{
    public class EpidemologicalWeekHelper : IEpidemologicalWeekHelper
    {
        public (int ewStart, int ewEnd, int eyStart, int eyEnd) GetLastSixMonths()
        {
            DateTime today = DateTime.Today;
            DateTime lastSixMonths = today.AddMonths(-6);

            var (ewStart, eyStart) = GetEpidemiologicalWeekAndYear(lastSixMonths);
            var (ewEnd, eyEnd) = GetEpidemiologicalWeekAndYear(today);

            return (ewStart, ewEnd, eyStart, eyEnd);
        }

        private static (int ew, int ey) GetEpidemiologicalWeekAndYear(DateTime date)
        {
            var culture = System.Globalization.CultureInfo.InvariantCulture;
            int week = culture.Calendar.GetWeekOfYear(
                date,
                System.Globalization.CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday
            );
            int year = date.Month == 1 && week >= 52 ? date.Year - 1 : date.Year;

            return (week, year);
        }
    }
}