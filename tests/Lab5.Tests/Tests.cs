using System.Collections.Generic;
using ApplicationEntity.Histories;
using ApplicationEntity.Users;
using Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Models.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public void WithdrawMoneyShouldSaveCorrectBalance()
    {
        var user = new User(1, 123, 0);
        var curUser = new CurrentUser();
        curUser.User = user;

        var users = new List<User>()
        {
            user,
        };

        var service = new UserService(
            new UserRepositoryMock(users),
            curUser,
            new HistoryRepositoryMock(),
            new HistoryService(new HistoryRepositoryMock()));

        service.AddMoney(1000);
        service.WithdrawMoney(500);

        Assert.Equal(500, curUser.User.Money);
    }

    [Fact]
    public void WithdrawMoneyShouldReturnError()
    {
        var user = new User(1, 123, 0);
        var curUser = new CurrentUser();
        curUser.User = user;

        var users = new List<User>()
        {
            user,
        };

        var service = new UserService(
            new UserRepositoryMock(users),
            curUser,
            new HistoryRepositoryMock(),
            new HistoryService(new HistoryRepositoryMock()));

        WithdrawMoneyResult result = service.WithdrawMoney(100);

        Assert.IsType<WithdrawMoneyResult.NotEnoughMoney>(result);
    }

    [Fact]
    public void AddMoneyShouldSuccess()
    {
        var user = new User(1, 123, 0);
        var curUser = new CurrentUser();
        curUser.User = user;

        var users = new List<User>()
        {
            user,
        };

        var service = new UserService(
            new UserRepositoryMock(users),
            curUser,
            new HistoryRepositoryMock(),
            new HistoryService(new HistoryRepositoryMock()));

        service.AddMoney(100);

        Assert.Equal(100, curUser.User.Money);
    }
}