using Contracts.Users;
using Models;
using Spectre.Console;

namespace Console.Scenarios.Users.ShowHistory;

public class ShowHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Show operations history";

    public void Run()
    {
        IEnumerable<OperationHistory> result = _userService.ShowHistory().ToList();

        if (result.Any())
        {
            foreach (OperationHistory history in result)
            {
                switch (history.Operation)
                {
                    case Operation.AddMoney:
                        AnsiConsole.WriteLine($"Added {history.Money}");
                        break;
                    case Operation.WithdrawMoney:
                        AnsiConsole.WriteLine($"Withdrawn {history.Money}");
                        break;
                }
            }
        }
        else
        {
            AnsiConsole.WriteLine("History is empty");
        }

        AnsiConsole.Ask<string>("Ok");
    }
}