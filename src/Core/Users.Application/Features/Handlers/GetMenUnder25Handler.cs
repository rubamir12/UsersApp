using MediatR;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Features.Queries;

namespace Users.Application.Features.Handlers
{
    public class GetMenUnder25Handler : IRequestHandler<GetMenUnder25Query, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;

        public GetMenUnder25Handler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetMenUnder25Query query, CancellationToken cancellationToken)
        {
            return await _userService.GetMenUnder25();
        }
    }
}
