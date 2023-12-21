using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Connect;

public class ConnectBuilder
{
    private string? _systemPath;
    private string? _mode;

    public ConnectBuilder WithPath(string path)
    {
        _systemPath = path;
        return this;
    }

    public ConnectBuilder WithMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public Connect Build()
    {
        return new Connect(
            _systemPath ?? throw new ArgumentNullException(),
            _mode ?? throw new ArgumentNullException());
    }
}