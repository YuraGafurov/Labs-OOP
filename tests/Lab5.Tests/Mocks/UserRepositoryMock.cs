using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repositories;
using Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class UserRepositoryMock : IUserRepository
{
    private IList<User> _users;

    public UserRepositoryMock(IList<User> users)
    {
        _users = users;
    }

    public Task<User?> FindUserById(long id) =>
        Task.FromResult(_users.ToList().Find(ac => ac.Id == id));

    public Task RegisterUser(int pin)
    {
        _users.Add(new User(_users[^1].Id + 1, pin, 0));
        return Task.CompletedTask;
    }

    public Task UpdateUserMoney(long id, double money)
    {
        User? user = _users.ToList().Find(ac => ac.Id == id);

        if (user is null)
        {
            return Task.CompletedTask;
        }

        user = new User(user.Id, user.Pin, money);
        return Task.CompletedTask;
    }
}