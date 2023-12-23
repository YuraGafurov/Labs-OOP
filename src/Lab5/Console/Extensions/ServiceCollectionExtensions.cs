using Console.Scenarios;
using Console.Scenarios.Admins.Login;
using Console.Scenarios.Admins.RegisterUser;
using Console.Scenarios.Users.AddMoney;
using Console.Scenarios.Users.Login;
using Console.Scenarios.Users.ShowBalance;
using Console.Scenarios.Users.ShowHistory;
using Console.Scenarios.Users.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();

        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegisterUserScenarioProvider>();

        return collection;
    }
}