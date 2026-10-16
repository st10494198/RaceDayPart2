
        [Fact]
        public void Enrolment_CanStoreEnrolmentDate()
        {
            // Arrange
            var enrolmentDate = new DateTime(2026, 11, 15);

            var enrolment = new Enrolment
            {
                EnrolmentDate = enrolmentDate
            };

            // Assert
            Assert.Equal(enrolmentDate, enrolment.EnrolmentDate);
        }
