using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type operation as enum
        (
            'addMoney',
            'withdrawMoney'
        );

        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_pin int not null ,
            user_money double precision not null
        );

        create table admins
        (
            admin_id bigint primary key generated always as identity ,
            admin_password text not null
        );

        create table history
        (
            history_id bigint primary key generated always as identity ,
            user_id bigint not null,
            operation operation not null ,
            money double precision not null
        );

        insert into admins (admin_password)
        values ('12345');
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop table admins;
        drop table history;
        drop type operation;
        """;
}