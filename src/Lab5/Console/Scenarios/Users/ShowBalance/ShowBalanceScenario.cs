using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Users.ShowBalance;

public class ShowBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Show balance";

    public void Run()
    {
        double result = _userService.ShowMoney();

        AnsiConsole.WriteLine($"{result}");
        AnsiConsole.Ask<string>("Ok");
    }
}