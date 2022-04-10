using MediatR;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Features.Queries;

namespace Users.Application.Features.Handlers
{
    public class GetWomenOver40Handler : IRequestHandler<GetWomenOver40Query, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;

        public GetWomenOver40Handler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetWomenOver40Query query, CancellationToken cancellationToken)
        {
            return await _userService.GetWomenOver40();
        }
    }
}
