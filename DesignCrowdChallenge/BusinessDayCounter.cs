using System;
using System.Collections.Generic;
using System.Linq;
using CounterLogic;

namespace DesignCrowdChallenge
{
    public class BusinessDayCounter
    {
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            WeekdayCounter weekdayCounter = new WeekdayCounter();
            var businessDays = weekdayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);
            if (businessDays == 0) //As per spec
                return 0;

            foreach (DateTime publicHoliday in publicHolidays)
            {
                //DateTime publicHolidayDate = publicHoliday.Date;
                if (firstDate.Date < publicHoliday.Date && publicHoliday.Date < secondDate.Date)
                    --businessDays;
            }

            return businessDays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IDictionary<int, IList<DateTime>> rules)
        {
            WeekdayCounter weekdayCounter = new WeekdayCounter();
            var businessDays = weekdayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);
            if (businessDays == 0) //As per spec
                return 0;

            foreach(var rule in rules.Keys)
            {
                switch(rule)
                {
                    case 1: //Rule 1 - Public holidays on the same day every year
                        IList<int> days = new List<int>() { 6, 1 };
                        IList<DateTime> dateListRule1 = new List<DateTime>();

                        foreach(DateTime date in rules[1])
                        {
                            for(int i = firstDate.Year; i <= secondDate.Year; i++)
                            {
                                dateListRule1.Add(new DateTime(i, date.Month, date.Day));
                            }
                        }

                        foreach(DateTime date in dateListRule1)
                        {
                            if (firstDate.Date < date.Date && date.Date < secondDate.Date && !days.Contains((int)date.DayOfWeek))
                            {
                                --businessDays;
                            }
                        }
                        break;

                    case 2: //Rule 2 - If public holiday is on a weekend, the next monday is the holiday
                        IList<DateTime> dateListRule2 = new List<DateTime>();

                        foreach (DateTime date in rules[2])
                        {
                            for (int i = firstDate.Year; i <= secondDate.Year; i++)
                            {
                                dateListRule2.Add(new DateTime(i, date.Month, date.Day));
                            }
                        }

                        foreach (DateTime date in dateListRule2)
                        {
                            if (firstDate.Date < date.Date && date.Date < secondDate.Date)
                            {
                                --businessDays;
                            }
                        }

                        break;

                    case 3: //Rule 3 - Public holiday occuring on the second Monday in a specific month
                        IList<DateTime> dateListRule3 = new List<DateTime>();

                        IEnumerable<DateTime> DaysInMonth(int year, int month) //Function makes it convinient to use LINQ to get mondays
                        {
                            var daysInMonth = DateTime.DaysInMonth(year, month);
                            for (int i = 1; i <= daysInMonth; i++)
                            {
                                yield return new DateTime(year, month, i);
                            }
                        }

                        foreach (DateTime date in rules[3])
                        {
                            for (int i = firstDate.Year; i <= secondDate.Year; i++)
                            {
                                IList<DateTime> allMondaysInMonth = DaysInMonth(i, date.Month)
                                    .Where(day => day.DayOfWeek == DayOfWeek.Monday).ToList();
                                dateListRule3.Add(allMondaysInMonth[1]);
                            }
                        }

                        foreach (DateTime date in dateListRule3)
                        {
                            if (firstDate.Date < date.Date && date.Date < secondDate.Date)
                            {
                                --businessDays;
                            }
                        }

                        break;

                    default:
                        Console.WriteLine("Rule does not exist");
                        break;
                }
            }
            return businessDays;
        }
    }
}
