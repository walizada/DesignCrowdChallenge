using System;

namespace DesignCrowdChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = new DateTime();
            var secondDate = new DateTime();

            try
            {
                Console.WriteLine("Enter first date in the format dd/mm/yyyy"); //Get fist date from user
                firstDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter second date in the format dd/mm/yyyy"); //Get second date from user
                secondDate = DateTime.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("\nInvalid value entered, unable to proceed\n");
                Environment.Exit(-1);
            }

            var seedData = new SeedData();

            var publicHolidays = seedData.PublicHolidays;
            var rules = seedData.Rules;

            var businessDays = new BusinessDayCounter();

            Console.Write("The number of weekdays between {0} and {1} is ", 
                (firstDate.Date).ToString("dd/MM/yyyy"), (secondDate.Date).ToString("dd/MM/yyyy"));
            Console.WriteLine(businessDays.WeekdaysBetweenTwoDates(firstDate, secondDate));

            Console.Write("The number of business days between {0} and {1} is ",
                (firstDate.Date).ToString("dd/MM/yyyy"), (secondDate.Date).ToString("dd/MM/yyyy"));
            Console.WriteLine(businessDays.BusinessDaysBetweenTwoDates(firstDate, secondDate,publicHolidays));

            Console.Write("The number of business days (based on rules) between {0} and {1} is ",
                (firstDate.Date).ToString("dd/MM/yyyy"), (secondDate.Date).ToString("dd/MM/yyyy"));
            Console.WriteLine(businessDays.BusinessDaysBetweenTwoDates(firstDate, secondDate, rules));
        }
    }
}
