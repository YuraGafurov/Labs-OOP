#pragma warning disable CA1034
namespace Contracts.Users;

public abstract record AddMoneyResult
{
    private AddMoneyResult() { }

    public sealed record Success : AddMoneyResult;

    public sealed record NotAuthorized : AddMoneyResult;
}
#pragma warning restore CA1034