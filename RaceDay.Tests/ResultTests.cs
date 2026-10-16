
using System;
using Xunit;
using RaceDay.Data;

namespace RaceDay.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Result_CanStoreRaceResultDetails()
        {
            var result = new Result
            {
                ResultID = 1,
                EnrolmentID = 8,
                FinishTime = new TimeSpan(0, 35, 0),
                Position = 1,
                Status = "Finished"
            };

            Assert.Equal(1, result.ResultID);
            Assert.Equal(8, result.EnrolmentID);
            Assert.Equal(new TimeSpan(0, 35, 0), result.FinishTime);
            Assert.Equal(1, result.Position);
            Assert.Equal("Finished", result.Status);
        }

        [Fact]
        public void Result_CanStoreAnotherFinishingPosition()
        {
            var result = new Result
            {
                EnrolmentID = 7,
                FinishTime = new TimeSpan(0, 40, 0),
                Position = 2,
                Status = "Finished"
            };

            Assert.Equal(new TimeSpan(0, 40, 0), result.FinishTime);
            Assert.Equal(2, result.Position);
            Assert.Equal("Finished", result.Status);
        }

        [Fact]
        public void Result_CanStoreDisqualifiedStatus()
        {
            var result = new Result
            {
                EnrolmentID = 9,
                FinishTime = TimeSpan.Zero,
                Position = 0,
                Status = "Disqualified"
            };

            Assert.Equal("Disqualified", result.Status);
            Assert.Equal(0, result.Position);
        }
    }
}
