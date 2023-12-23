using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.Users.ShowBalance;

public class ShowBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public ShowBalanceScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowBalanceScenario(_userService);
        return true;
    }
}