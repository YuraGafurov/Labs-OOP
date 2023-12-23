using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.Repositories;
using Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class HistoryRepositoryMock : IHistoryRepository
{
    public IAsyncEnumerable<OperationHistory>? GetAllUserHistory(long userId)
    {
        return null;
    }

    public Task SaveUserHistory(long userId, Operation operation, double money)
    {
        return Task.CompletedTask;
    }
}