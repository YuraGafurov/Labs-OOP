using Models.Admins;

namespace Contracts.Admins;

public interface ICurrentAdminService
{
    Admin? Admin { get; }
}