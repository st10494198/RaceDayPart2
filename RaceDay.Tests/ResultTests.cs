
        [Fact]
        public void Result_CanStoreDisqualifiedStatus()
        {
            // Arrange
            var result = new Result
            {
                EnrolmentID = 9,
                FinishTime = TimeSpan.Zero,
                Position = 0,
                Status = "Disqualified"
            };

            // Assert
            Assert.Equal("Disqualified", result.Status);
            Assert.Equal(0, result.Position);
        }
