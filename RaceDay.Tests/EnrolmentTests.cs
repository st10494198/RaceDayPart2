
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
    }
}
