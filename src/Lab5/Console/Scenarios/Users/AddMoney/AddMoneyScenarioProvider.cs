using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.Users.AddMoney;

public class AddMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public AddMoneyScenarioProvider(
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

        scenario = new AddMoneyScenario(_userService);
        return true;
    }
}