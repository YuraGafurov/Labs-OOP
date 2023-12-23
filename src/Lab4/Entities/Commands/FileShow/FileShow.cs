using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileShow;

public class FileShow : ICommand
{
    private string _path;
    private string _flags;

    public FileShow(string path, string flags)
    {
        _path = path;
        _flags = flags;
    }

    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        if (!Path.Exists(_path)) return new ExecutionResult(false, "Path does not exist");
        fileSystem.FileShow(_path, _flags);
        return new ExecutionResult(true, "Command was completed successfully");
    }
}