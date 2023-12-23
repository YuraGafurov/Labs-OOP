using Models;

namespace Abstractions.Repositories;

public interface IHistoryRepository
{
    IAsyncEnumerable<OperationHistory>? GetAllUserHistory(long userId);
    Task SaveUserHistory(long userId, Operation operation, double money);
}