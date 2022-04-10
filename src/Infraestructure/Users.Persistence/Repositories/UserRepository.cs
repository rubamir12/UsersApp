using Users.Application.Abstractions;
using Users.Application.Enums;
using Users.Domain.Entities;

namespace Users.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserData _userData;
        public UserRepository(IUserData usersData)
        {
            _userData = usersData;
        }

        public IEnumerable<User> GetAll()
        {
            return _userData.Users;
        }

        public IEnumerable<User> GetUsersUnderAge(Gender gender, int age)
        {
            string genderString = Enum.GetName(typeof(Gender), gender)!;
            return _userData.Users.Where(x => x.Gender == genderString && x.Age < age);
        }

        public User? GetYoungestUserByGender(Gender gender)
        {
            string genderString = Enum.GetName(typeof(Gender), gender)!;
            return _userData.Users.Where(x => x.Gender == genderString)?.MinBy(x => x.Age);
        }

        public IEnumerable<User> GetUsersOverAge(Gender gender, int age)
        {
            string genderString = Enum.GetName(typeof(Gender), gender)!;
            return _userData.Users.Where(x => x.Gender == genderString && x.Age > age);
        }

        public IEnumerable<User> GetUsersWithRoles(Gender gender, List<Role> roleList)
        {
            string genderString = Enum.GetName(typeof(Gender), gender)!;
            List<string> roleStringList = new();
            roleList.ForEach(x => roleStringList.Add(Enum.GetName(typeof(Role), x)!));
            return _userData.Users.Where(x => x.Gender == genderString && !roleStringList.Except(x.Roles).Any());
        }

        public IEnumerable<User> GetUsersWithRoleAndPrefix(Role role, string prefix)
        {
            string roleString = Enum.GetName(typeof(Role), role)!;
            return _userData.Users.Where(x => x.Roles.Contains(roleString) && x.FirstName.StartsWith(prefix));
        }
    }
}
