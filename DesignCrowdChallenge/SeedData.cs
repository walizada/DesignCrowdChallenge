using System;
using System.Collections.Generic;

namespace DesignCrowdChallenge
{
    public class SeedData //Helper class to initilaise the list (Task 2) and rules (task 3)
    {
        public IDictionary<int, IList<DateTime>> Rules { get; set; } = new Dictionary<int, IList<DateTime>>() //In all cases, using the current year to iniialise list because year will be ignored during calculation
            {
                {1, new List<DateTime>{ new DateTime(DateTime.Now.Year,4,25), new DateTime(DateTime.Now.Year, 12, 25), new DateTime(DateTime.Now.Year, 12, 26) } }, //Rule 1 - Public holidays on the same day every year
                {2, new List<DateTime>{ new DateTime(DateTime.Now.Year,1,1), new DateTime(DateTime.Now.Year, 1, 26) } }, //Rule 2 - If public holiday is on a weekend, the next monday is the holiday
                {3, new List<DateTime>{ new DateTime(DateTime.Now.Year,6,DateTime.Now.Day)} } //Rule 3 - Public holiday occuring on the second Monday in a specific month
            };
        public IList<DateTime> PublicHolidays { get; set; } = new List<DateTime>() //Sample list of public holidays, given in the spec
            {
                new DateTime(2013,12,25),
                new DateTime(2013,12,26),
                new DateTime(2014,1,1)
            };
    }
}
