namespace Contracts.Admins;

public interface IAdminService
{
    AdminLoginResult Login(long id, string password);
    void RegisterUser(int pin);
}