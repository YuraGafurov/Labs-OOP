using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserById(long id);
    Task RegisterUser(int pin);
    Task UpdateUserMoney(long id, double money);
}