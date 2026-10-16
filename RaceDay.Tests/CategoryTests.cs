
        [Fact]
        public void Category_CanStoreHalfMarathonDistance()
        {
            // Arrange
            var category = new Category
            {
                CategoryName = "Half Marathon",
                Distance = 21.1,
                EventID = 12
            };

            // Assert
            Assert.Equal("Half Marathon", category.CategoryName);
            Assert.Equal(21.1, category.Distance);
            Assert.Equal(12, category.EventID);
        }
