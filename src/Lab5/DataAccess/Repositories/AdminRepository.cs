using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Admins;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Admin?> FindAdminById(long id)
    {
        const string sql = """
                           select admin_id, admin_password
                           from admins
                           where admin_id = :id;
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

        return new Admin(
            Id: reader.GetInt64(0),
            Password: reader.GetString(1));
    }

    public async Task UpdateAdminPassword(long id, string password)
    {
        const string sql = """
                           update admins
                           set admin_password = :password
                           where admin_id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("password", password);
        command.AddParameter("id", id);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}