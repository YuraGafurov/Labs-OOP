#pragma warning disable CA1034
namespace Contracts.Admins;

public abstract record AdminLoginResult
{
    private AdminLoginResult() { }

    public sealed record Success : AdminLoginResult;

    public sealed record AdminNotFound : AdminLoginResult;

    public sealed record IncorrectPassword : AdminLoginResult;
}
#pragma warning restore CA1034