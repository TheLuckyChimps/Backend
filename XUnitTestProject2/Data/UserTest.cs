using FluentAssertions;
using TPL.Data.Entities;
using TPL.Data.Entities.Fakers;
using TPL.Data.Enums;
using Xunit;

namespace XUnitTestProject2.Data
{
    [Trait("User | Data | Entities", nameof(User))]
    public class UserTest
    {
        private readonly UserDataFaker userDataFaker = new UserDataFaker();

        [Fact]
        internal void GivenUserProfileEntityWhenGeneratedWithDataFakerThenVerifyAllProperties()
        {
            // Arrange

            // Act
            var users = userDataFaker.FakeUserProfile.Generate(count: 10);

            // Assert
            users.ForEach(userProfile =>
            {
                userProfile.Id.Should().NotBeEmpty();
                userProfile.Name.Should().NotBeNullOrEmpty();
                userProfile.Name.Length.Should().BeLessOrEqualTo(50);
                userProfile.Surname.Should().NotBeNullOrEmpty();
                userProfile.Surname.Length.Should().BeLessOrEqualTo(50);
                userProfile.Password.Should().NotBeNullOrEmpty();
                userProfile.Password.Length.Should().BeLessOrEqualTo(50);
                userProfile.Email.Should().NotBeNullOrEmpty();
                userProfile.Email.Length.Should().BeLessOrEqualTo(50);
                userProfile.Address.Should().NotBeNull();
                userProfile.Address.Length.Should().BeLessOrEqualTo(100);
               // userProfile.Role.Should();
               // userProfile.Role.Should().Be<UserRole>();

            });
        }
    }
}
