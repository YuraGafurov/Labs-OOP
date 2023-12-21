using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileDelete;

public class FileDelete : ICommand
{
    private string _path;

    public FileDelete(string path)
    {
        _path = path;
    }

    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        if (!Path.Exists(_path)) return new ExecutionResult(false, "Path does not exist");

        fileSystem.FileDelete(_path);

        return new ExecutionResult(true, "File was successfully deleted");
    }
}