using Abstractions.Repositories;
using Contracts.Histories;
using Contracts.Users;
using Models;
using Models.Users;

namespace ApplicationEntity.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly CurrentUser _currentUser;
    private readonly IHistoryRepository _historyRepository;
    private readonly IHistoryService _historyService;

    public UserService(IUserRepository userRepository, CurrentUser currentUser, IHistoryRepository historyRepository, IHistoryService historyService)
    {
        _currentUser = currentUser;
        _userRepository = userRepository;
        _historyRepository = historyRepository;
        _historyService = historyService;
    }

    public UserLoginResult Login(long id, int pin)
    {
        User? user = _userRepository.FindUserById(id).Result;

        if (user is null)
        {
            return new UserLoginResult.UserNotFound();
        }

        if (user.Pin != pin)
        {
            return new UserLoginResult.IncorrectPin();
        }

        _currentUser.User = user;
        return new UserLoginResult.Success();
    }

    public double ShowMoney()
    {
        return _currentUser.User?.Money ?? 0;
    }

    public AddMoneyResult AddMoney(double money)
    {
        if (_currentUser.User is null)
        {
            return new AddMoneyResult.NotAuthorized();
        }

        _userRepository.UpdateUserMoney(
            _currentUser.User.Id,
            _currentUser.User.Money + money);

        _currentUser.User = new User(
            _currentUser.User.Id,
            _currentUser.User.Pin,
            _currentUser.User.Money + money);

        _historyService.SaveHistory(_currentUser.User.Id, Operation.AddMoney, money);
        return new AddMoneyResult.Success();
    }

    public WithdrawMoneyResult WithdrawMoney(double money)
    {
        if (_currentUser.User is null)
        {
            return new WithdrawMoneyResult.NotAuthorized();
        }

        if (_currentUser.User.Money < money)
        {
            return new WithdrawMoneyResult.NotEnoughMoney();
        }

        _userRepository.UpdateUserMoney(
            _currentUser.User.Id,
            _currentUser.User.Money - money);

        _currentUser.User = new User(
            _currentUser.User.Id,
            _currentUser.User.Pin,
            _currentUser.User.Money - money);

        _historyService.SaveHistory(_currentUser.User.Id, Operation.WithdrawMoney, money);
        return new WithdrawMoneyResult.Success();
    }

    public IEnumerable<OperationHistory> ShowHistory()
    {
        if (_currentUser.User is null)
        {
            return new List<OperationHistory>();
        }

        IAsyncEnumerable<OperationHistory>? history = _historyRepository.GetAllUserHistory(_currentUser.User.Id);

        if (history is null)
        {
            return new List<OperationHistory>();
        }

        return history.ToBlockingEnumerable();
    }
}