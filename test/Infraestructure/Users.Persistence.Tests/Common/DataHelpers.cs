using System.Collections.Generic;
using Users.Domain.Entities;

namespace Users.Persistence.Tests.Common
{
    public static class DataHelpers
    {
        public static List<User> users = new()
        {
            new User()
            {
                Id = 1,
                FirstName = "Joel",
                LastName = "Peeters",
                Gender = "Male",
                Age = 45,
                Roles = new List<string>()
                    {
                        "Manager", "Admin"
                    }
            },
            new User()
            {
                Id = 2,
                FirstName = "Janice",
                LastName = "Janssens",
                Gender = "Female",
                Age = 29,
                Roles = new List<string>()
                    {
                        "Manager", "Admin"
                    }
            },
            new User()
            {
                Id = 3,
                FirstName = "Marcos",
                LastName = "Maes",
                Gender = "Male",
                Age = 22,
                Roles = new List<string>()
                    {
                        "Manager", "Admin"
                    }
            },
            new User()
            {
                Id = 4,
                FirstName = "Maria",
                LastName = "Jacobs",
                Gender = "Female",
                Age = 23,
                Roles = new List<string>()
                    {
                        "Employee"
                    }
            },
            new User()
            {
                Id = 5,
                FirstName = "Nuria",
                LastName = "Mertens",
                Gender = "Female",
                Age = 62,
                Roles = new List<string>()
                    {
                        "Manager", "Admin",  "Employee"
                    }
            },
            new User()
            {
                Id = 6,
                FirstName = "Jona",
                LastName = "Willems",
                Gender = "Female",
                Age = 45,
                Roles = new List<string>()
                    {
                        "Manager"
                    }
            },
            new User()
            {
                Id = 6,
                FirstName = "Jose",
                LastName = "Claes",
                Gender = "Male",
                Age = 54,
                Roles = new List<string>()
                    {
                        "Employee", "Admin"
                    }
            },
            new User()
            {
                Id = 7,
                FirstName = "Ester",
                LastName = "Goossens",
                Gender = "Female",
                Age = 30,
                Roles = new List<string>()
                    {
                        "Employee"
                    }
            },
            new User()
            {
                Id = 8,
                FirstName = "Ismael",
                LastName = "Wouters",
                Gender = "Male",
                Age = 24,
                Roles = new List<string>()
                    {
                        "Employee"
                    }
            },
            new User()
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
    }
}
