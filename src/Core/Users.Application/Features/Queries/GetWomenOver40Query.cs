using MediatR;
using Users.Application.Dtos;

namespace Users.Application.Features.Queries
{
    public record GetWomenOver40Query() : IRequest<IEnumerable<UserDto>>;
}
