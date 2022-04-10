using Users.Domain.Entities;

namespace Users.Application.Abstractions
{
    public interface IUserData
    {
        IEnumerable<User> Users { get; }
    }
}
