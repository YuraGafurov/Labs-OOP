using Models;

namespace Contracts.Histories;

public interface IHistoryService
{
    void SaveHistory(long userId, Operation operation, double money);
}