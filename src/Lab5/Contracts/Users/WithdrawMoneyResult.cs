#pragma warning disable CA1034
namespace Contracts.Users;

public abstract record WithdrawMoneyResult
{
    private WithdrawMoneyResult() { }

    public sealed record Success : WithdrawMoneyResult;

    public sealed record NotAuthorized : WithdrawMoneyResult;

    public sealed record NotEnoughMoney : WithdrawMoneyResult;
}
#pragma warning restore CA1034