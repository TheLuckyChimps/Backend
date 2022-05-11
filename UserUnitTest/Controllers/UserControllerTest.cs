using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UserUnitTest.Controllers
{
    [Trait("User | Controllers", nameof(UserController))]
    public class UserControllerTest
    {


        [Fact]
        [Trait("HttpVerb", "GET")]
        internal async Task GivenGetByIdAsyncCalledWhenDataExistThenReturnsData()
        {
            // Arrange
            mockUserProfileService
                .Setup(_ => _.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(It.IsAny<UserProfileView>())
                .Verifiable();

            // Act
            var result = await userProfileController.GetByIdAsync(It.IsAny<Guid>());

            // Assert
            mockUserProfileService.VerifySetup();
            mockLog.VerifyNoOtherCalls();
            result.Should().BeOfType<OkObjectResult>("because we return expected content");
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
