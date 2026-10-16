
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using RaceDay.Controllers;
using Xunit;

namespace RaceDay.Tests
{
    public class AuthorizationTests
    {
        [Fact]
        public void CreateCategory_RequiresOrganiserRole()
        {
            var method = typeof(CategoriesController)
                .GetMethod(nameof(CategoriesController.CreateCategory));

            Assert.NotNull(method);

            var attribute = method!
                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                .Cast<AuthorizeAttribute>()
                .FirstOrDefault();

            Assert.NotNull(attribute);
            Assert.Equal("Organiser", attribute!.Roles);
        }

        [Fact]
        public void UpdateCategory_RequiresOrganiserRole()
        {
            var method = typeof(CategoriesController)
                .GetMethod(nameof(CategoriesController.UpdateCategory));

            Assert.NotNull(method);

            var attribute = method!
                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                .Cast<AuthorizeAttribute>()
                .FirstOrDefault();

            Assert.NotNull(attribute);
            Assert.Equal("Organiser", attribute!.Roles);
        }

        [Fact]
        public void DeleteCategory_RequiresOrganiserRole()
        {
            var method = typeof(CategoriesController)
                .GetMethod(nameof(CategoriesController.DeleteCategory));

            Assert.NotNull(method);

            var attribute = method!
                .GetCustomAttributes(typeof(AuthorizeAttribute), true)
                .Cast<AuthorizeAttribute>()
                .FirstOrDefault();

            Assert.NotNull(attribute);
            Assert.Equal("Organiser", attribute!.Roles);
        }
    }
}
