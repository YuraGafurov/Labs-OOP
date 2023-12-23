using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.Admins.RegisterUser;

public class RegisterUserScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdmin;

    public RegisterUserScenarioProvider(
        IAdminService adminService,
        ICurrentAdminService currentAdmin)
    {
        _adminService = adminService;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is null)
        {
            scenario = null;
            return false;
        }

        scenario = new RegisterUserScenario(_adminService);
        return true;
    }
}