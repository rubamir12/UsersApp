using Users.Application.Dtos;

namespace Users.Application.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetMenUnder25();
        Task<UserDto> GetYoungestMan();
        Task<IEnumerable<UserDto>> GetWomenOver40();
        Task<IEnumerable<UserDto>> GetWomenWithManagerAndAdminRoles();
        Task<IEnumerable<UserDto>> GetManagersStartingWithJo();
        Task<string> ExportUsersToFile();
    }
}
