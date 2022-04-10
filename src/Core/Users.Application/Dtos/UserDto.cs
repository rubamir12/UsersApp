using Users.Application.Enums;

namespace Users.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
