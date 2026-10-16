
        [Fact]
        public void Event_CanStoreDifferentLocationAndDescription()
        {
            // Arrange
            var raceEvent = new Event
            {
                Location = "Johannesburg",
                Description = "Annual road running event"
            };

            // Assert
            Assert.Equal("Johannesburg", raceEvent.Location);
            Assert.Equal(
                "Annual road running event",
                raceEvent.Description);
        }
