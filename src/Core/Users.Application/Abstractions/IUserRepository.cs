using Users.Application.Enums;
using Users.Domain.Entities;

namespace Users.Application.Abstractions
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> GetUsersUnderAge(Gender gender, int age);
        User? GetYoungestUserByGender(Gender gender);
        IEnumerable<User> GetUsersOverAge(Gender gender, int age);
        IEnumerable<User> GetUsersWithRoles(Gender gender, List<Role> roleList);
        IEnumerable<User> GetUsersWithRoleAndPrefix(Role role, string prefix);
    }
}
