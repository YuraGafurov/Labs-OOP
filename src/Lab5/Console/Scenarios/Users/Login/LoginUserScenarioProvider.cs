using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.Users.Login;

public class LoginUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public LoginUserScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUserService)
    {
        _userService = userService;
        _currentUser = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginUserScenario(_userService);
        return true;
    }
}