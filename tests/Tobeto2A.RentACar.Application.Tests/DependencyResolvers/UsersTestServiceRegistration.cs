using Application.Features.Users.Commands.Create;

using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using Microsoft.Extensions.DependencyInjection;
using StarterProject.Application.Tests.Mocks.FakeDatas;

namespace StarterProject.Application.Tests.DependencyResolvers;

public static class UsersTestServiceRegistration
{
    public static void AddUsersServices(this IServiceCollection services)
    {
        services.AddTransient<UserFakeData>();
        services.AddTransient<CreateUserCommand>();

        services.AddTransient<GetByIdUserQuery>();
        services.AddTransient<GetListUserQuery>();
  
    }
}
