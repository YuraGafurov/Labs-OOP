using Models.Admins;

namespace Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Admin?> FindAdminById(long id);
    Task UpdateAdminPassword(long id, string password);
}