using FluentAssertions;
using FluentAssertions.Execution;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users.Api.Controllers;
using Users.Application.Dtos;
using Users.Application.Features.Queries;
using Xunit;

namespace Users.Api.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly UserController _controller;

        private readonly Mock<IMediator> _mediatorMock = new();

        public UserControllerTest()
        {
            _controller = new UserController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetMenUnder25_ReturnsEmptyList()
        {
            // Arrange
            _mediatorMock.Setup(c => c.Send(It.IsAny<GetMenUnder25Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Enumerable.Empty<UserDto>());

            // Act
            ActionResult<IEnumerable<UserDto>> response = await _controller.GetMenUnder25().ConfigureAwait(false);

            // Assert
            using (new AssertionScope())
            {
                response.Result.Should().NotBeNull();

                OkObjectResult? result = response.Result as OkObjectResult;
                result!.StatusCode.Should().Be(StatusCodes.Status200OK);

                IEnumerable<UserDto>? responseResult = (response.Result as OkObjectResult)!.Value as IEnumerable<UserDto>;
                responseResult!.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task GetYoungestMan_ReturnsUser()
        {
            // Arrange
            _mediatorMock.Setup(c => c.Send(It.IsAny<GetYoungestManQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UserDto());

            // Act
            ActionResult<UserDto> response = await _controller.GetYoungestMan().ConfigureAwait(false);

            // Assert
            using (new AssertionScope())
            {
                response.Result.Should().NotBeNull();

                OkObjectResult? result = response.Result as OkObjectResult;
                result!.StatusCode.Should().Be(StatusCodes.Status200OK);

                UserDto? responseResult = (response.Result as OkObjectResult)!.Value as UserDto;
                responseResult!.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task GetWomenOver40_ReturnsEmptyList()
        {
            // Arrange
            _mediatorMock.Setup(c => c.Send(It.IsAny<GetWomenOver40Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Enumerable.Empty<UserDto>());

            // Act
            ActionResult<IEnumerable<UserDto>> response = await _controller.GetWomenOver40().ConfigureAwait(false);

            // Assert
            using (new AssertionScope())
            {
                response.Result.Should().NotBeNull();

                OkObjectResult? result = response.Result as OkObjectResult;
                result!.StatusCode.Should().Be(StatusCodes.Status200OK);

                IEnumerable<UserDto>? responseResult = (response.Result as OkObjectResult)!.Value as IEnumerable<UserDto>;
                responseResult!.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task GetWomenWithManagerAndAdminRoles_ReturnsEmptyList()
        {
            // Arrange
            _mediatorMock.Setup(c => c.Send(It.IsAny<GetWomenWithManagerAndAdminRolesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Enumerable.Empty<UserDto>());

            // Act
            ActionResult<IEnumerable<UserDto>> response = await _controller.GetWomenWithManagerAndAdminRoles().ConfigureAwait(false);

            // Assert
            using (new AssertionScope())
            {
                response.Result.Should().NotBeNull();

                OkObjectResult? result = response.Result as OkObjectResult;
                result!.StatusCode.Should().Be(StatusCodes.Status200OK);

                IEnumerable<UserDto>? responseResult = (response.Result as OkObjectResult)!.Value as IEnumerable<UserDto>;
                responseResult!.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task GetManagersStartingWithJo_ReturnsEmptyList()
        {
            // Arrange
            _mediatorMock.Setup(c => c.Send(It.IsAny<GetManagersStartingWithJoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Enumerable.Empty<UserDto>());

            // Act
            ActionResult<IEnumerable<UserDto>> response = await _controller.GetManagersStartingWithJo().ConfigureAwait(false);

            // Assert
            using (new AssertionScope())
            {
                response.Result.Should().NotBeNull();

                OkObjectResult? result = response.Result as OkObjectResult;
                result!.StatusCode.Should().Be(StatusCodes.Status200OK);

                IEnumerable<UserDto>? responseResult = (response.Result as OkObjectResult)!.Value as IEnumerable<UserDto>;
                responseResult!.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task ExportUsersToFile_ReturnsExpectedResult()
        {
            // Arrange
            _mediatorMock.Setup(c => c.Send(It.IsAny<ExportUsersToFileQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("ok");

            // Act
            ActionResult<string> response = await _controller.ExportUsersToFile().ConfigureAwait(false);

            // Assert
            using (new AssertionScope())
            {
                response.Result.Should().NotBeNull();

                OkObjectResult? result = response.Result as OkObjectResult;
                result!.StatusCode.Should().Be(StatusCodes.Status200OK);

                string? responseResult = (response.Result as OkObjectResult)!.Value as string;
                responseResult!.Should().Be("ok");
            }
        }
    }
}
