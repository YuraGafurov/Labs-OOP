using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.Admins.Login;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login as admin";

    public void Run()
    {
        long adminId = AnsiConsole.Ask<long>("Enter your id");
        string password = AnsiConsole.Ask<string>("Enter your password");

        AdminLoginResult result = _adminService.Login(adminId, password);

        string message = result switch
        {
            AdminLoginResult.Success => "Successful",
            AdminLoginResult.AdminNotFound => "Admin not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}