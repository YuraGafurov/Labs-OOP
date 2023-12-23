using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Users.AddMoney;

public class AddMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public AddMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Add money";

    public void Run()
    {
        double money = AnsiConsole.Ask<double>("How much money you want to add?");

        AddMoneyResult result = _userService.AddMoney(money);

        string message = result switch
        {
            AddMoneyResult.Success => "Successful",
            AddMoneyResult.NotAuthorized => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}