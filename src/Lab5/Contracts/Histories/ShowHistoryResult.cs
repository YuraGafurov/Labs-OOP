#pragma warning disable CA1034
namespace Contracts.Histories;

public abstract record ShowHistoryResult
{
    private ShowHistoryResult() { }

    public sealed record NotAuthorized : ShowHistoryResult;

    public sealed record NoOperationsFound : ShowHistoryResult;
}
#pragma warning restore CA1034