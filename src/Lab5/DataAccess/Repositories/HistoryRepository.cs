using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models;
using Npgsql;

namespace DataAccess.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public HistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<OperationHistory>? GetAllUserHistory(long userId)
    {
        const string sql = """
                           select history_id, user_id, operation, money
                           from history
                           where user_id = :id;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", userId);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (!await reader.ReadAsync().ConfigureAwait(false))
        {
            yield break;
        }

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            yield return new OperationHistory(
                reader.GetInt64(0),
                reader.GetInt64(1),
                await reader.GetFieldValueAsync<Operation>(2).ConfigureAwait(false),
                reader.GetDouble(3));
        }
    }

    public async Task SaveUserHistory(long userId, Operation operation, double money)
    {
        const string sql = """
                           insert into history (user_id, operation, money)
                           values (:user_id, :operation, :money)
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("user_id", userId);
        command.AddParameter("operation", operation);
        command.AddParameter("money", money);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}