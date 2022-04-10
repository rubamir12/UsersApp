using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Abstractions;
using Users.Application.Enums;
using Users.Domain.Entities;
using Users.Persistence.Repositories;
using Users.Persistence.Tests.Common;
using Xunit;

namespace Users.Persistence.Tests.Repositories
{
    public class UserRepositoryTest
    {
        private readonly UserRepository _serviceUnderTest;
        private readonly Mock<IUserData> _userData = new();

        public UserRepositoryTest()
        {
            _userData.SetupGet(x => x.Users).Returns(DataHelpers.users);

            _serviceUnderTest = new UserRepository(_userData.Object);
        }

        [Fact]
        public async Task GetUsersUnderAge_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> expectedResult = new()
            {
                new()
                {
                    Id = 9,
                    FirstName = "Martha",
                    LastName = "De Smet",
                    Gender = "Female",
                    Age = 18,
                    Roles = new List<string>()
                    {
                        "Employee"
                    }
                }
            };

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersUnderAge(Gender.Female, 19);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetUsersUnderAge_GivenEmptyList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new();

            List<User> expectedResult = new();

            _userData.SetupGet(x => x.Users).Returns(entryParameters);

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersUnderAge(Gender.Female, 19);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetYoungestUserByGender_GivenCorrectUser_ThenReturnsExpectedResult()
        {
            // Arrange
            User expectedResult = new()
            {
                Id = 9,
                FirstName = "Martha",
                LastName = "De Smet",
                Gender = "Female",
                Age = 18,
                Roles = new List<string>()
                {
                    "Employee"
                }
            };

            // Act
            User result = _serviceUnderTest.GetYoungestUserByGender(Gender.Female);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetYoungestUserByGender_GivenNullUser_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new();

            User expectedResult = null;

            _userData.SetupGet(x => x.Users).Returns(entryParameters);

            // Act
            User result = _serviceUnderTest.GetYoungestUserByGender(Gender.Female);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetUsersOverAge_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> expectedResult = new()
            {
                new()
                {
                    Id = 5,
                    FirstName = "Nuria",
                    LastName = "Mertens",
                    Gender = "Female",
                    Age = 62,
                    Roles = new List<string>()
                    {
                        "Manager", "Admin", "Employee"
                    }
                }
            };

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersOverAge(Gender.Female, 61);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetUsersOverAge_GivenEmptyList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new();

            List<User> expectedResult = new();

            _userData.SetupGet(x => x.Users).Returns(entryParameters);

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersOverAge(Gender.Male, 49);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetUsersWithRoles_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> expectedResult = new()
            {
                new()
                {
                    Id = 5,
                    FirstName = "Nuria",
                    LastName = "Mertens",
                    Gender = "Female",
                    Age = 62,
                    Roles = new List<string>()
                    {
                        "Manager", "Admin", "Employee"
                    }
                }
            };

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersWithRoles(Gender.Female, new List<Role>() { Role.Manager, Role.Admin, Role.Employee });

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetUsersWithRoles_GivenEmptyList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new();

            List<User> expectedResult = new();

            _userData.SetupGet(x => x.Users).Returns(entryParameters);

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersWithRoles(Gender.Male, new List<Role>() { Role.Manager, Role.Admin });

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetUsersWithRoleAndPrefix_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> expectedResult = new()
            {
                new()
                {
                    Age = 45,
                    FirstName = "Joel",
                    Gender = "Male",
                    Id = 1,
                    LastName = "Peeters",
                    Roles = new List<string>()
                    { 
                        "Manager", 
                        "Admin" 
                    }
            },
                new()
                {    
                    Age = 45, 
                    FirstName = "Jona", 
                    Gender = "Female", 
                    Id = 6, 
                    LastName = "Willems",
                    Roles = new List<string>()
                    { 
                        "Manager"
                    }
                }
        };

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersWithRoleAndPrefix(Role.Manager, "Jo");

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetUsersWithRoleAndPrefix_GivenEmptyList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new();

            List<User> expectedResult = new();

            _userData.SetupGet(x => x.Users).Returns(entryParameters);

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetUsersWithRoleAndPrefix(Role.Manager, "Jo");

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetAll_GivenCorrectList_ThenReturnsExpectedResult()
        {
            // Arrange
            IEnumerable<User> expectedResult = DataHelpers.users;

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetAll();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task GetAll_GivenEmptyList_ThenReturnsExpectedResult()
        {
            // Arrange
            List<User> entryParameters = new();

            List<User> expectedResult = new();

            _userData.SetupGet(x => x.Users).Returns(entryParameters);

            // Act
            IEnumerable<User> result = _serviceUnderTest.GetAll();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
