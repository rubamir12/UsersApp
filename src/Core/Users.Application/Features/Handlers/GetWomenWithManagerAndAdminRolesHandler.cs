using MediatR;
using Users.Application.Abstractions;
using Users.Application.Dtos;
using Users.Application.Features.Queries;

namespace Users.Application.Features.Handlers
{
    public class GetWomenWithManagerAndAdminRolesHandler : IRequestHandler<GetWomenWithManagerAndAdminRolesQuery, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;

        public GetWomenWithManagerAndAdminRolesHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetWomenWithManagerAndAdminRolesQuery query, CancellationToken cancellationToken)
        {
            return await _userService.GetWomenWithManagerAndAdminRoles();
        }
    }
}
