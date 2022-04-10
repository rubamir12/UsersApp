using MediatR;
using Users.Application.Dtos;

namespace Users.Application.Features.Queries
{
    public record GetMenUnder25Query() : IRequest<IEnumerable<UserDto>>;
}
