
using Xunit;
using RaceDay.Data;

namespace RaceDay.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void Category_CanStoreCategoryDetails()
        {
            var category = new Category
            {
                CategoryID = 1,
                CategoryName = "5km Fun Run",
                Distance = 5,
                EventID = 11
            };

            Assert.Equal(1, category.CategoryID);
            Assert.Equal("5km Fun Run", category.CategoryName);
            Assert.Equal(5, category.Distance);
            Assert.Equal(11, category.EventID);
        }

        [Fact]
        public void Category_CanStoreDifferentDistance()
        {
            var category = new Category
            {
                CategoryName = "10km Race",
                Distance = 10,
                EventID = 11
            };

            Assert.Equal("10km Race", category.CategoryName);
            Assert.Equal(10, category.Distance);
        }

        [Fact]
        public void Category_CanStoreHalfMarathonDistance()
        {
            var category = new Category
            {
                CategoryName = "Half Marathon",
                Distance = 21.1,
                EventID = 12
            };

            Assert.Equal("Half Marathon", category.CategoryName);
            Assert.Equal(21.1, category.Distance);
            Assert.Equal(12, category.EventID);
        }
    }
}
