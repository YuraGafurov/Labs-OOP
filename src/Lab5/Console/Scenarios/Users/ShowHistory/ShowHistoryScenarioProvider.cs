using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.Users.ShowHistory;

public class ShowHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public ShowHistoryScenarioProvider(
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

        scenario = new ShowHistoryScenario(_userService);
        return true;
    }
}