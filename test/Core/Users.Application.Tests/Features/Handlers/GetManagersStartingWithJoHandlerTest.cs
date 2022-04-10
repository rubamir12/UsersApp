using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Enums;
using Users.Application.Features.Handlers;
using Users.Application.Features.Queries;
using Xunit;

namespace Users.Application.Tests.Features.Handlers
{
    public class GetManagersStartingWithJoHandlerTest
    {
        private readonly Mock<IUserService> _userServiceMock = new();

        [Fact]
        public async Task GetManagersStartingWithJoHandler_GivenCorrectData_ThenReturnsExpectedData()
        {
            // Arrange
            List<UserDto> usersMock = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = Gender.Female,
                    Age = 20,
                    Roles = new List<Role>()
                        {
                            Role.Manager
                        }
                }
            };

            _userServiceMock.Setup(c => c.GetManagersStartingWithJo()).Returns(Task.FromResult(usersMock.AsEnumerable()));
            GetManagersStartingWithJoHandler handler = new(_userServiceMock.Object);

            // Act
            IEnumerable<UserDto> result = await handler.Handle(new GetManagersStartingWithJoQuery(), new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(usersMock);
        }

        [Fact]
        public async Task GetManagersStartingWithJoHandler_GivenNullData_ThenReturnsNull()
        {
            // Arrange
            IEnumerable<UserDto> usersMock = null;

            _userServiceMock.Setup(c => c.GetManagersStartingWithJo()).Returns(Task.FromResult(usersMock));
            GetManagersStartingWithJoHandler handler = new(_userServiceMock.Object);

            // Act
            IEnumerable<UserDto> result = await handler.Handle(new GetManagersStartingWithJoQuery(), new CancellationToken());

            // Assert
            result.Should().BeNull();
        }
    }
}
