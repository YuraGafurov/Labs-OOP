using Models;

namespace Contracts.Users;

public interface IUserService
{
    UserLoginResult Login(long id, int pin);
    double ShowMoney();
    AddMoneyResult AddMoney(double money);
    WithdrawMoneyResult WithdrawMoney(double money);
    IEnumerable<OperationHistory> ShowHistory();
}