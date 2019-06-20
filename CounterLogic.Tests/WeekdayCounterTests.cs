using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CounterLogic.Tests
{
    [TestFixture]
    public class WeekdayCounterTests
    {
        private WeekdayCounter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new WeekdayCounter();
        }

        [Test]
        public void FirstTestForWeekDaysBetweenTwoDates()
        {
            var result = _sut.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9));

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void SecondTestForWeekDaysBetweenTwoDates()
        {
            var result = _sut.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14));

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void ThirdTestForWeekDaysBetweenTwoDates()
        {
            var result = _sut.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1));

            Assert.That(result, Is.EqualTo(61));
        }

        [Test]
        public void FourthTestForWeekDaysBetweenTwoDates()
        {
            int result = _sut.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5));

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
