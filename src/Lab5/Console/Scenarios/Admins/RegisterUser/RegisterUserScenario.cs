using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.Admins.RegisterUser;

public class RegisterUserScenario : IScenario
{
    private readonly IAdminService _adminService;

    public RegisterUserScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Register new user";

    public void Run()
    {
        int pin = AnsiConsole.Ask<int>("Enter users pin");

        _adminService.RegisterUser(pin);

        string message = $"Registered new user";

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}