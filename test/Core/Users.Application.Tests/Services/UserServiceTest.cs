using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Enums;
using Users.Application.Profiles;
using Users.Application.Services;
using Users.Domain.Entities;
using Xunit;

namespace Users.Application.Tests.Services
{
    public class UserServiceTest
    {
        private readonly UserService _serviceUnderTest;
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IFileExporterService> _fileExporterServiceMock = new();

        public UserServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _serviceUnderTest = new UserService(mapper, _userRepositoryMock.Object, _fileExporterServiceMock.Object);
        }

        [Fact]
        public async Task GetMenUnder25_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = "Male",
                    Age = 20,
                    Roles = new List<string>()
                        {
                            "Employee"
                        }
                }
            };

            List<UserDto> expectedResult = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = Gender.Male,
                    Age = 20,
                    Roles = new List<Role>()
                        {
                            Role.Employee
                        }
                }
            };

            _userRepositoryMock.Setup(x => x.GetUsersUnderAge(Gender.Male, 25)).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetMenUnder25();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetMenUnder25_GivenNullList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = null;

            List<UserDto> expectedResult = new();

            _userRepositoryMock.Setup(x => x.GetUsersUnderAge(Gender.Male, 25)).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetMenUnder25();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetYoungestMan_GivenCorrectUser_ThenReturnsExpectedResult()
        {
            // Arrange
            User entryParameters = new()
            {
                Id = 1,
                FirstName = "Joel",
                LastName = "Peeters",
                Gender = "Male",
                Age = 20,
                Roles = new List<string>()
                {
                    "Employee"
                }
            };

            UserDto expectedResult = new()
            {
                Id = 1,
                FirstName = "Joel",
                LastName = "Peeters",
                Gender = Gender.Male,
                Age = 20,
                Roles = new List<Role>()
                {
                    Role.Employee
                }
            };

            _userRepositoryMock.Setup(x => x.GetYoungestUserByGender(Gender.Male)).Returns(entryParameters);

            // Act
            UserDto result = await _serviceUnderTest.GetYoungestMan();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetYoungestMan_GivenNullUser_ThenReturnsExpectedResult()
        {
            // Arrange
            User entryParameters = null;

            UserDto expectedResult = null;

            _userRepositoryMock.Setup(x => x.GetYoungestUserByGender(Gender.Male)).Returns(entryParameters);

            // Act
            UserDto result = await _serviceUnderTest.GetYoungestMan();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetWomenOver40_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = "Female",
                    Age = 50,
                    Roles = new List<string>()
                        {
                            "Employee"
                        }
                }
            };

            List<UserDto> expectedResult = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = Gender.Female,
                    Age = 50,
                    Roles = new List<Role>()
                        {
                            Role.Employee
                        }
                }
            };

            _userRepositoryMock.Setup(x => x.GetUsersOverAge(Gender.Female, 40)).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetWomenOver40();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetWomenOver40_GivenNullList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = null;

            List<UserDto> expectedResult = new();

            _userRepositoryMock.Setup(x => x.GetUsersOverAge(Gender.Female, 40)).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetWomenOver40();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetWomenWithManagerAndAdminRoles_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = "Female",
                    Age = 50,
                    Roles = new List<string>()
                        {
                            "Manager",
                            "Admin"
                        }
                }
            };

            List<UserDto> expectedResult = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = Gender.Female,
                    Age = 50,
                    Roles = new List<Role>()
                        {
                            Role.Manager,
                            Role.Admin
                        }
                }
            };

            _userRepositoryMock.Setup(x => x.GetUsersWithRoles(Gender.Female, new List<Role>() { Role.Manager, Role.Admin })).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetWomenWithManagerAndAdminRoles();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetWomenWithManagerAndAdminRoles_GivenNullList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = null;

            List<UserDto> expectedResult = new();

            _userRepositoryMock.Setup(x => x.GetUsersWithRoles(Gender.Female, new List<Role>() { Role.Manager, Role.Admin })).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetWomenWithManagerAndAdminRoles();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetManagersStartingWithJo_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = "Female",
                    Age = 50,
                    Roles = new List<string>()
                        {
                            "Manager",
                            "Admin"
                        }
                }
            };

            List<UserDto> expectedResult = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = Gender.Female,
                    Age = 50,
                    Roles = new List<Role>()
                        {
                            Role.Manager,
                            Role.Admin
                        }
                }
            };

            _userRepositoryMock.Setup(x => x.GetUsersWithRoleAndPrefix(Role.Manager, "Jo")).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetManagersStartingWithJo();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetManagersStartingWithJo_GivenNullList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = null;

            List<UserDto> expectedResult = new();

            _userRepositoryMock.Setup(x => x.GetUsersWithRoleAndPrefix(Role.Manager, "Jo")).Returns(entryParameters);

            // Act
            IEnumerable<UserDto> result = await _serviceUnderTest.GetManagersStartingWithJo();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task ExportUsersToFile_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Joel",
                    LastName = "Peeters",
                    Gender = "Male",
                    Age = 20,
                    Roles = new List<string>()
                        {
                            "Employee"
                        }
                }
            };

            string expectedResult = "ok";

            _userRepositoryMock.Setup(x => x.GetAll()).Returns(entryParameters);

            _fileExporterServiceMock.Setup(x => x.ExportUsersFile(It.IsAny<IEnumerable<UserDto>>())).Returns(Task.FromResult(expectedResult));

            // Act
            string result = await _serviceUnderTest.ExportUsersToFile();

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public async Task ExportUsersToFile_GivenNullList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = null;

            string expectedResult = "nok";

            _userRepositoryMock.Setup(x => x.GetAll()).Returns(entryParameters);

            _fileExporterServiceMock.Setup(x => x.ExportUsersFile(It.IsAny<IEnumerable<UserDto>>())).Returns(Task.FromResult(expectedResult));

            // Act
            string result = await _serviceUnderTest.ExportUsersToFile();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
