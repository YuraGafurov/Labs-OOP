using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeGoto;

public class TreeGoto : ICommand
{
    private string _path;

    public TreeGoto(string path)
    {
        _path = path;
    }

    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        if (!Path.Exists(_path)) return new ExecutionResult(false, "Path does not exist");
        fileSystem.TreeGoto(_path);
        return new ExecutionResult(true, "Path was changed successfully");
    }
}