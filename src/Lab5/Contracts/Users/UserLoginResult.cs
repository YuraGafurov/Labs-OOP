#pragma warning disable CA1034
namespace Contracts.Users;

public abstract record UserLoginResult
{
    private UserLoginResult() { }

    public sealed record Success : UserLoginResult;

    public sealed record UserNotFound : UserLoginResult;

    public sealed record IncorrectPin : UserLoginResult;
}
#pragma warning restore CA1034