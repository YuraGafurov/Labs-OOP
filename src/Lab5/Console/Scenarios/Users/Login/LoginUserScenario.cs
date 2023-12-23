using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Users.Login;

public class LoginUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login as user";

    public void Run()
    {
        long userId = AnsiConsole.Ask<long>("Enter your id");
        int pin = AnsiConsole.Ask<int>("Enter your pin-code");

        UserLoginResult result = _userService.Login(userId, pin);

        string message = result switch
        {
            UserLoginResult.Success => "Successful",
            UserLoginResult.UserNotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}