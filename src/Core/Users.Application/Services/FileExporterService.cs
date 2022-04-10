using Syroot.Windows.IO;
using System.Text;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Enums;

namespace Users.Application.Services
{
    public class FileExporterService : IFileExporterService
    {
        public async Task<string> ExportUsersFile(IEnumerable<UserDto> userList)
        {
            string fileName = @$"{new KnownFolder(KnownFolderType.Downloads).Path}\{DateTime.Now:yyyyMMddHHmmss}.txt";

            try
            {
                using FileStream fs = File.Create(fileName);
                foreach (var user in userList)
                {
                    string genderString = Enum.GetName(typeof(Gender), user.Gender)!;
                    string heOrShe = user.Gender == Gender.Female ? "She" : "He";
                    Byte[] text = new UTF8Encoding(true).GetBytes($"{user.FirstName} {user.LastName} is {user.Age} old. It is a {genderString}. {heOrShe} has the following roles: {string.Join(",", user.Roles)}.\n");
                    await fs.WriteAsync(text);
                }

                return $"File exported successfully in {fileName}.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
