using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Users.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw money";

    public void Run()
    {
        double money = AnsiConsole.Ask<double>("How much money you want to withdraw?");

        WithdrawMoneyResult result = _userService.WithdrawMoney(money);

        string message = result switch
        {
            WithdrawMoneyResult.Success => "Successful",
            WithdrawMoneyResult.NotEnoughMoney => "Not enough money",
            WithdrawMoneyResult.NotAuthorized => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}