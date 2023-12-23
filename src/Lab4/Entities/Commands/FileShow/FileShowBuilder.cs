using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileShow;

public class FileShowBuilder
{
    private string? _path;
    private string? _mode;

    public FileShowBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileShowBuilder WithMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public FileShow Build()
    {
        return new FileShow(
            _path ?? throw new ArgumentNullException(),
            _mode ?? throw new ArgumentNullException());
    }
}