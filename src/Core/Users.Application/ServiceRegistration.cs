using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Users.Application.Abstractions;
using Users.Application.Features.Queries;
using Users.Application.Profiles;
using Users.Application.Services;

namespace Users.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var config = new MapperConfiguration(c => {
                c.AddProfile<UserProfile>();
            });
            services.AddSingleton(s => config.CreateMapper());

            services.AddScoped<IFileExporterService, FileExporterService>();
            services.AddScoped<IUserService, UserService>();

            services.AddMediatR(typeof(ExportUsersToFileQuery).GetTypeInfo().Assembly);

            return services;
        }
    }
}
