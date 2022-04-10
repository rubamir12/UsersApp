using MediatR;

namespace Users.Application.Features.Queries
{
    public record ExportUsersToFileQuery() : IRequest<string>;
}
