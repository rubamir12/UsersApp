using MediatR;
using Users.Application.Abstractions;
using Users.Application.Features.Queries;

namespace Users.Application.Features.Handlers
{
    public class ExportUsersToFileHandler : IRequestHandler<ExportUsersToFileQuery, string>
    {
        private readonly IUserService _userService;

        public ExportUsersToFileHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(ExportUsersToFileQuery query, CancellationToken cancellationToken)
        {
            return await _userService.ExportUsersToFile();
        }
    }
}
