using FluentAssertions;
using Moq;
using System.Collections.Generic;
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
    public class GetYoungestManHandlerTest
    {
        private readonly Mock<IUserService> _userServiceMock = new();

        [Fact]
        public async Task GetYoungestManHandler_GivenCorrectData_ThenReturnsExpectedData()
        {
            // Arrange
            UserDto userMock = new()
            {
                Id = 1,
                FirstName = "Joel",
                LastName = "Peeters",
                Gender = Gender.Male,
                Age = 45,
                Roles = new List<Role>()
                    {
                        Role.Employee
                    }
            };

            _userServiceMock.Setup(c => c.GetYoungestMan()).Returns(Task.FromResult(userMock));
            GetYoungestManHandler handler = new(_userServiceMock.Object);

            // Act
            UserDto result = await handler.Handle(new GetYoungestManQuery(), new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(userMock);
        }

        [Fact]
        public async Task GetYoungestManHandler_GivenNullData_ThenReturnsNull()
        {
            // Arrange
            UserDto userMock = null;

            _userServiceMock.Setup(c => c.GetYoungestMan()).Returns(Task.FromResult(userMock));
            GetYoungestManHandler handler = new(_userServiceMock.Object);

            // Act
            UserDto result = await handler.Handle(new GetYoungestManQuery(), new CancellationToken());

            // Assert
            result.Should().BeNull();
        }
    }
}
