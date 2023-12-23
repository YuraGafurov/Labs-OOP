using Contracts.Admins;
using Models.Admins;

namespace ApplicationEntity.Admins;

public class CurrentAdmin : ICurrentAdminService
{
    public Admin? Admin { get; set; }
}