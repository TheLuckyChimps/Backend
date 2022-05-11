using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos;
using TPL.Data.Dtos.UserDtosFaker;
using TPL.Data.Entities;
using TPL.Data.Entities.Fakers;
using TPL.Data.Exceptions;
using TPL.Repository.Interfaces;
using TPL.Servicies;
using TPL.Servicies.Interfaces;
using Xunit;

namespace XUnitTestProject2.Services
{
    [Trait("User | Services", nameof(UserService))]
    public class UserServiceTest
    {
        private readonly IUserService userService;
        private readonly Mock<IUserRepository> mockUserRepository;
        // private readonly Mock<IConfigurationService> mockConfigurationService;
        //private readonly Mock<IConfiguration> mockConfiguration;
        private readonly Mock<IOptions<AppSettings>> mockAppSettings;
        private readonly Mock<IMapper> mockMapper;

        private readonly UserDataFaker userDataFaker = new UserDataFaker();
        private readonly UserCreateDtoFaker userDtoDataFaker = new UserCreateDtoFaker();
        private readonly UserResponseDtoFaker userProfileResponseFaker = new UserResponseDtoFaker();

        public UserServiceTest()
        {
            mockUserRepository = new Mock<IUserRepository>();
            mockMapper = new Mock<IMapper>();
            mockAppSettings = new Mock<IOptions<AppSettings>>();
            // mockConfigurationService = new Mock<IConfigurationService>();
            // mockConfiguration = new Mock<IConfiguration>();

            userService = new UserService(
                mockUserRepository.Object,
               // mockConfiguration.Object,
               // mockConfigurationService.Object,
                mockMapper.Object,
                mockAppSettings.Object);
        }

        [Fact]
        internal async Task GivenCreateAsyncCalledWhenInputIsValidThenCreatesData()
        {
            // Arrange
            var email = "test@test.com";
            var userProfileAdd = userDtoDataFaker.FakeUserProfileAdd.Generate();
            var userProfile = userDataFaker.FakeUserProfile.Generate();
            var userProfileResponse = userProfileResponseFaker.FakeUserProfileResponse.Generate();
            //var userProfileTrace = userDtoDataFaker.FakeUserProfileTrace.Generate();

            mockUserRepository
                .Setup(_ => _.GetByEmail( email))
                .ReturnsAsync((User)null)
                .Verifiable();
            mockMapper
                .Setup(_ => _.Map<User>(userProfileAdd))
                .Returns(userProfile)
                .Verifiable();
            mockUserRepository
                .Setup(_ => _.InsertAsync(userProfile))
                .ReturnsAsync(userProfile)
                .Verifiable();
            mockMapper
                .Setup(_ => _.Map<UserResponseDto>(userProfile))
                .Returns(userProfileResponse)
                .Verifiable();

            // Act
            var result = await userService.CreateUser(userProfileAdd);

            // Assert
            //mockUserRepository.VerifySetup();
           // mockMapper.VerifySetup();
            //mockConfigurationService.VerifySetup();
           // mockApiRequest.VerifySetup();
            result.Should().BeOfType<UserResponseDto>();
            result.Should().BeSameAs(userProfileResponse);
            userProfile.Email.Should().Be(email);
            await Assert.ThrowsAsync<AlreadyExistException>(() => userService.CreateUser(userProfileAdd));
        }
    }
}
