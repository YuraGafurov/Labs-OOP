using Contracts.Users;
using Models.Users;

namespace ApplicationEntity.Users;

public class CurrentUser : ICurrentUserService
{
    public User? User { get; set; }
}