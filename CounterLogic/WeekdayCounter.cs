using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterLogic
{
    public class WeekdayCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            firstDate = firstDate.Date;
            secondDate = secondDate.Date;

            if (secondDate <= firstDate) //As per spec
                return 0;

            TimeSpan interval = secondDate - firstDate;
            var totalDays = interval.Days - 1; //To exclude the first and last dates as per spec
            var fullWeeks = totalDays / 7;

            if (totalDays > fullWeeks * 7)
            {
                var firstDayOfWeek = (int)firstDate.DayOfWeek + 1;
                var secondDayOfWeek = (int)secondDate.DayOfWeek - 1;
                if (secondDayOfWeek == -1)
                    secondDayOfWeek = 6;
                if (secondDayOfWeek == 0)
                    secondDayOfWeek = 7;

                if (firstDayOfWeek > secondDayOfWeek)
                    secondDayOfWeek += 7;

                if (firstDayOfWeek <= 6)
                {
                    if (secondDayOfWeek == 7)
                        totalDays -= 2;
                    else if (secondDayOfWeek == 6)
                        totalDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && secondDayOfWeek >= 7)
                    totalDays -= 1;
            }

            var weekdays = totalDays - (fullWeeks * 2);
            return weekdays;
        }

    }
}
