using Users.Application.Dtos;

namespace Users.Application.Abstractions
{
    public interface IFileExporterService
    {
        Task<string> ExportUsersFile(IEnumerable<UserDto> userList);
    }
}
