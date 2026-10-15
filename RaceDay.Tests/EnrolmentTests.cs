using Xunit;
using RaceDay.Data;

namespace RaceDay.Tests
{
    public class EnrolmentTests
    {
        [Fact]
        public void Enrolment_CanStoreEnrolmentDetails()
        {
            // Arrange
            var enrolment = new Enrolment
            {
                EnrolmentID = 7,
                UserID = 9,
                CategoryID = 30,
                RaceNumber = 102
            };

            // Assert
            Assert.Equal(7, enrolment.EnrolmentID);
            Assert.Equal(9, enrolment.UserID);
            Assert.Equal(30, enrolment.CategoryID);
            Assert.Equal(102, enrolment.RaceNumber);
        }

        [Fact]
        public void Enrolment_CanStoreDifferentRaceNumber()
        {
            // Arrange
            var enrolment = new Enrolment
            {
                UserID = 9,
                CategoryID = 1,
                RaceNumber = 101
            };

            // Assert
            Assert.Equal(101, enrolment.RaceNumber);
            Assert.Equal(1, enrolment.CategoryID);
        }
    }
}
