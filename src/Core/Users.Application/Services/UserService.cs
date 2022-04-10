using AutoMapper;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Enums;

namespace Users.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IFileExporterService _fileExporterService;
        public UserService(IMapper mapper, IUserRepository userRepository, IFileExporterService fileExporterService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _fileExporterService = fileExporterService;
        }

        public async Task<IEnumerable<UserDto>> GetMenUnder25()
        {
            var result = _userRepository.GetUsersUnderAge(Gender.Male, 25);
            return await Task.FromResult(_mapper.Map<IEnumerable<UserDto>>(result));
        }

        public async Task<UserDto> GetYoungestMan()
        {
            var result = _userRepository.GetYoungestUserByGender(Gender.Male);
            return await Task.FromResult(_mapper.Map<UserDto>(result));
        }

        public async Task<IEnumerable<UserDto>> GetWomenOver40()
        {
            var result = _userRepository.GetUsersOverAge(Gender.Female, 40);
            return await Task.FromResult(_mapper.Map<IEnumerable<UserDto>>(result));
        }

        public async Task<IEnumerable<UserDto>> GetWomenWithManagerAndAdminRoles()
        {
            var result = _userRepository.GetUsersWithRoles(Gender.Female, new List<Role>() { Role.Manager, Role.Admin });
            return await Task.FromResult(_mapper.Map<IEnumerable<UserDto>>(result));
        }

        public async Task<IEnumerable<UserDto>> GetManagersStartingWithJo()
        {
            var result = _userRepository.GetUsersWithRoleAndPrefix(Role.Manager, "Jo");
            return await Task.FromResult(_mapper.Map<IEnumerable<UserDto>>(result));
        }

        public async Task<string> ExportUsersToFile()
        {
            var result = _userRepository.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<UserDto>>(result);
            return await _fileExporterService.ExportUsersFile(mappedResult);
        }
    }
}