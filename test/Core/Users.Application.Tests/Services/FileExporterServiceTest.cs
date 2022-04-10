using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Dtos;
using Users.Application.Enums;
using Users.Application.Services;
using Xunit;

namespace Users.Application.Tests.Services
{
    public class FileExporterServiceTest
    {
        private readonly FileExporterService _serviceUnderTest = new();

        [Fact]
        public async Task ExportUsersFile_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<UserDto> users = new()
            {
                new UserDto()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = Gender.Male,
                    Age = 45,
                    Roles = new List<Role>()
                    {
                        Role.Manager, Role.Admin
                    }
                }
            };

            // Act
            string result = await _serviceUnderTest.ExportUsersFile(users);

            // Assert
            result.Should().Contain("File exported successfully in");
        }

        [Fact]
        public async Task ExportUsersFile_GivenNullList_ThenReturnsExceptionMessage()
        {
            // Act
            string result = await _serviceUnderTest.ExportUsersFile(null);

            // Assert
            result.Should().Contain("Object reference not set to an instance of an object.");
        }
    }
}
