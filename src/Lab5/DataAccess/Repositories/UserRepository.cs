using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Users;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserById(long id)
    {
        const string sql = """
        select user_id, user_pin, user_money
        from users
        where user_id = :id;
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (!await reader.ReadAsync().ConfigureAwait(false))
        {
            return null;
        }

        return new User(
            Id: reader.GetInt64(0),
            Pin: reader.GetInt32(1),
            Money: reader.GetDouble(2));
    }

    public async Task RegisterUser(int pin)
    {
        const string sql = """
        insert into users (user_pin, user_money)
        values (:pin, 0);
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("pin", pin);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task UpdateUserMoney(long id, double money)
    {
        const string sql = """
        update users
        set user_money = :money
        where user_id = :id
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("money", money);
        command.AddParameter("id", id);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}