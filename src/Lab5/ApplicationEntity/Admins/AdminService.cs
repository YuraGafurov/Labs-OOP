using Abstractions.Repositories;
using Contracts.Admins;
using Models.Admins;

namespace ApplicationEntity.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly CurrentAdmin _currentAdmin;
    private readonly IUserRepository _userRepository;

    public AdminService(IAdminRepository adminRepository, CurrentAdmin currentAdmin, IUserRepository userRepository)
    {
        _currentAdmin = currentAdmin;
        _adminRepository = adminRepository;
        _userRepository = userRepository;
    }

    public AdminLoginResult Login(long id, string password)
    {
        Admin? admin = _adminRepository.FindAdminById(id).Result;

        if (admin is null)
        {
            return new AdminLoginResult.AdminNotFound();
        }

        if (admin.Password != password)
        {
            return new AdminLoginResult.IncorrectPassword();
        }

        _currentAdmin.Admin = admin;
        return new AdminLoginResult.Success();
    }

    public void RegisterUser(int pin)
    {
        _userRepository.RegisterUser(pin);
    }
}