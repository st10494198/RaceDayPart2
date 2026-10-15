
using Xunit;
using RaceDay.Data;

namespace RaceDay.Tests
{
    public class EventTests
    {
        [Fact]
        public void Event_CanStoreEventDetails()
        {
            // Arrange
            var raceEvent = new Event
            {
                EventID = 11,
                EventName = "RaceDay Test Run",
                EventDate = new DateTime(2026, 11, 15, 8, 0, 0),
                Location = "Pretoria",
                Description = "Test event for the RaceDay system",
                OrganiserID = 10
            };

            // Assert
            Assert.Equal(11, raceEvent.EventID);
            Assert.Equal("RaceDay Test Run", raceEvent.EventName);
            Assert.Equal("Pretoria", raceEvent.Location);
            Assert.Equal(10, raceEvent.OrganiserID);
        }
    }
}
