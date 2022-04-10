using MediatR;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Features.Queries;

namespace Users.Application.Features.Handlers
{
    public class GetYoungestManHandler : IRequestHandler<GetYoungestManQuery, UserDto>
    {
        private readonly IUserService _userService;

        public GetYoungestManHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetYoungestManQuery query, CancellationToken cancellationToken)
        {
            return await _userService.GetYoungestMan();
        }
    }
}
