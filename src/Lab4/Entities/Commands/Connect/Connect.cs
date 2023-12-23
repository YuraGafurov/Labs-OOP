using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Connect;

public class Connect : ICommand
{
    private string _systemPath;
    private string _mode;

    public Connect(string path, string mode)
    {
        _systemPath = path;
        _mode = mode;
    }

    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        if (!Path.Exists(_systemPath)) return new ExecutionResult(false, "Path does not exist");
        fileSystem.Connect(_systemPath, _mode);
        return new ExecutionResult(true, "Connected to file system");
    }
}