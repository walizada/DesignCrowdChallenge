using DesignCrowdChallenge;
using NUnit.Framework;
using System;

namespace DesignCrowdChallengeTests
{
    [TestFixture]
    public class UnitTests
    {
        private BusinessDayCounter bdc;
        private SeedData seedData;

        [SetUp]
        public void SetUp()
        {
            bdc = new BusinessDayCounter();
            seedData = new SeedData();
        }

        [Test]
        public void FirstTestForWeekDaysBetweenTwoDates()
        {
            var result = bdc.WeekdaysBetweenTwoDates(new DateTime(2013,10,7), new DateTime(2013,10,9));

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void SecondTestForWeekDaysBetweenTwoDates()
        {
            var result = bdc.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14));

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void ThirdTestForWeekDaysBetweenTwoDates()
        {
            var result = bdc.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1));

            Assert.That(result, Is.EqualTo(61));
        }

        [Test]
        public void FourthTestForWeekDaysBetweenTwoDates()
        {
            int result = bdc.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5));

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void FirstTestForBusinessDaysBetweenTwoDates()
        {
            int result = bdc.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9),seedData.PublicHolidays);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void SecondTestForBusinessDaysBetweenTwoDates()
        {
            int result = bdc.BusinessDaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), seedData.PublicHolidays);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ThirdTestForBusinessDaysBetweenTwoDates()
        {
            int result = bdc.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), seedData.PublicHolidays);

            Assert.That(result, Is.EqualTo(59));
        }

        [Test]
        public void FirstTestForBusinessDaysBetweenTwoDatesUsingRules()
        {
            int result = bdc.BusinessDaysBetweenTwoDates(new DateTime(2013, 5, 7), new DateTime(2014, 12, 31), seedData.Rules);

            Assert.That(result, Is.EqualTo(421));
        }

        [Test]
        public void SecondTestForBusinessDaysBetweenTwoDatesUsingRules()
        {
            int result = bdc.BusinessDaysBetweenTwoDates(new DateTime(2019, 5, 31), new DateTime(2019, 7, 1), seedData.Rules);

            Assert.That(result, Is.EqualTo(19));
        }
    }
}
