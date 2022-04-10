using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Abstractions;
using Users.Application.Features.Handlers;
using Users.Application.Features.Queries;
using Xunit;

namespace Users.Application.Tests.Features.Handlers
{
    public class ExportUsersToFileHandlerTest
    {
        private readonly Mock<IUserService> _userServiceMock = new();

        [Fact]
        public async Task ExportUsersToFileHandler_GivenCorrectData_ThenReturnsExpectedData()
        {
            // Arrange
            string expectedResult = "ok";

            _userServiceMock.Setup(c => c.ExportUsersToFile()).Returns(Task.FromResult(expectedResult));
            ExportUsersToFileHandler handler = new(_userServiceMock.Object);

            // Act
            string result = await handler.Handle(new ExportUsersToFileQuery(), new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task ExportUsersToFileHandler_GivenNullData_ThenReturnsNull()
        {
            // Arrange
            string expectedResult = null;

            _userServiceMock.Setup(c => c.ExportUsersToFile()).Returns(Task.FromResult(expectedResult));
            ExportUsersToFileHandler handler = new(_userServiceMock.Object);

            // Act
            string result = await handler.Handle(new ExportUsersToFileQuery(), new CancellationToken());

            // Assert
            result.Should().BeNull();
        }
    }
}
