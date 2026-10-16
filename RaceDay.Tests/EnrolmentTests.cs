
using System;
using Xunit;
using RaceDay.Data;

namespace RaceDay.Tests
{
    public class EnrolmentTests
    {
        [Fact]
        public void Enrolment_CanStoreEnrolmentDetails()
        {
            var enrolment = new Enrolment
            {
                EnrolmentID = 7,
                UserID = 9,
                CategoryID = 30,
                RaceNumber = 102
            };

            Assert.Equal(7, enrolment.EnrolmentID);
            Assert.Equal(9, enrolment.UserID);
            Assert.Equal(30, enrolment.CategoryID);
            Assert.Equal(102, enrolment.RaceNumber);
        }

        [Fact]
        public void Enrolment_CanStoreDifferentRaceNumber()
        {
            var enrolment = new Enrolment
            {
                UserID = 9,
                CategoryID = 1,
                RaceNumber = 101
            };

            Assert.Equal(101, enrolment.RaceNumber);
            Assert.Equal(1, enrolment.CategoryID);
        }

        [Fact]
        public void Enrolment_CanStoreEnrolmentDate()
        {
            var enrolmentDate = new DateTime(2026, 11, 15);

            var enrolment = new Enrolment
            {
                EnrolmentDate = enrolmentDate
            };

            Assert.Equal(enrolmentDate, enrolment.EnrolmentDate);
        }
    }
}
