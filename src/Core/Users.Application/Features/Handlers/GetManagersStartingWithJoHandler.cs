using MediatR;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Features.Queries;

namespace Users.Application.Features.Handlers
{
    public class GetManagersStartingWithJoHandler : IRequestHandler<GetManagersStartingWithJoQuery, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;

        public GetManagersStartingWithJoHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetManagersStartingWithJoQuery query, CancellationToken cancellationToken)
        {
            return await _userService.GetManagersStartingWithJo();
        }
    }
}
