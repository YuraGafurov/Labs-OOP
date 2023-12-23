using ApplicationEntity.Admins;
using ApplicationEntity.Histories;
using ApplicationEntity.Users;
using Contracts.Admins;
using Contracts.Histories;
using Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationEntity.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<IHistoryService, HistoryService>();

        collection.AddScoped<CurrentUser>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUser>());

        collection.AddScoped<CurrentAdmin>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdmin>());

        return collection;
    }
}