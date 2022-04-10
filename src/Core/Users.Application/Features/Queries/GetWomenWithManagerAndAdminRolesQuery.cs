using MediatR;
using Users.Application.Dtos;

namespace Users.Application.Features.Queries
{
    public record GetWomenWithManagerAndAdminRolesQuery() : IRequest<IEnumerable<UserDto>>;
}
