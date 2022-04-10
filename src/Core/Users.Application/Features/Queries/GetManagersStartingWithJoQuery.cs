using MediatR;
using Users.Application.Dtos;

namespace Users.Application.Features.Queries
{
    public record GetManagersStartingWithJoQuery() : IRequest<IEnumerable<UserDto>>;
}
