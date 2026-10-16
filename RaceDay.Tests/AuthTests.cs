
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using RaceDay.Data;
using RaceDay.Controllers;
using Xunit;

namespace RaceDay.Tests
{
    public class AuthTests
    {
        [Fact]
        public void Password_IsHashedAndCanBeVerified()
        {
            var user = new User();
            var hasher = new PasswordHasher<User>();
            string password = "RaceDay@123";

            string hashedPassword =
                hasher.HashPassword(user, password);

            Assert.NotEqual(password, hashedPassword);

            var result = hasher.VerifyHashedPassword(
                user, hashedPassword, password);

            Assert.Equal(
                PasswordVerificationResult.Success, result);
        }

        [Fact]
        public void IncorrectPassword_FailsVerification()
        {
            var user = new User();
            var hasher = new PasswordHasher<User>();

            string hashedPassword =
                hasher.HashPassword(user, "RaceDay@123");

            var result = hasher.VerifyHashedPassword(
                user, hashedPassword, "WrongPassword@123");

            Assert.Equal(
                PasswordVerificationResult.Failed, result);
        }

        [Fact]
        public void RegisterRequest_RejectsInvalidEmail()
        {
            var request = new RegisterRequest
            {
                FirstName = "Jay",
                LastName = "Test",
                Email = "not-an-email",
                Password = "RaceDay@123",
                Role = "Participant"
            };

            var context =
                new ValidationContext(request);

            var errors = new List<ValidationResult>();

            bool valid = Validator.TryValidateObject(
                request, context, errors, true);

            Assert.False(valid);
        }

        [Fact]
        public void RegisterRequest_RejectsShortPassword()
        {
            var request = new RegisterRequest
            {
                FirstName = "Jay",
                LastName = "Test",
                Email = "jay@example.com",
                Password = "123",
                Role = "Participant"
            };

            var context =
                new ValidationContext(request);

            var errors = new List<ValidationResult>();

            bool valid = Validator.TryValidateObject(
                request, context, errors, true);

            Assert.False(valid);
        }
    }
}
