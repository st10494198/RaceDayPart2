
using System;
using Xunit;
using RaceDay.Data;

namespace RaceDay.Tests
{
    public class EventTests
    {
        [Fact]
        public void Event_CanStoreEventDetails()
        {
            var eventDate = new DateTime(2026, 11, 15, 8, 0, 0);

            var raceEvent = new Event
            {
                EventID = 11,
                EventName = "RaceDay Test Run",
                EventDate = eventDate,
                Location = "Pretoria",
                Description = "Test event for the RaceDay system",
                OrganiserID = 10
            };

            Assert.Equal(11, raceEvent.EventID);
            Assert.Equal("RaceDay Test Run", raceEvent.EventName);
            Assert.Equal(eventDate, raceEvent.EventDate);
            Assert.Equal("Pretoria", raceEvent.Location);
            Assert.Equal("Test event for the RaceDay system", raceEvent.Description);
            Assert.Equal(10, raceEvent.OrganiserID);
        }

        [Fact]
        public void Event_CanStoreDifferentLocationAndDescription()
        {
            var raceEvent = new Event
            {
                Location = "Johannesburg",
                Description = "Annual road running event"
            };

            Assert.Equal("Johannesburg", raceEvent.Location);
            Assert.Equal("Annual road running event", raceEvent.Description);
        }
    }
}
