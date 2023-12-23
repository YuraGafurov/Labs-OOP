using Abstractions.Repositories;
using Contracts.Histories;
using Models;

namespace ApplicationEntity.Histories;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;

    public HistoryService(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public void SaveHistory(long userId, Operation operation, double money)
    {
        _historyRepository.SaveUserHistory(userId, operation, money);
    }
}