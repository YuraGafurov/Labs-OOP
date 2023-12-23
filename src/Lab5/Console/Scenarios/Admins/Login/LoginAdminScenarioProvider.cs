using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.Admins.Login;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdmin;

    public LoginAdminScenarioProvider(
        IAdminService adminService,
        ICurrentAdminService currentAdminService)
    {
        _adminService = adminService;
        _currentAdmin = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAdminScenario(_adminService);
        return true;
    }
}