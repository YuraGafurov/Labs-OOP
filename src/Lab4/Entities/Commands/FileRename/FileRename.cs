using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileRename;

public class FileRename : ICommand
{
    private string _path;
    private string _name;

    public FileRename(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        if (!Path.Exists(_path)) return new ExecutionResult(false, "Path does not exist");
        if (_name.Length == 0) return new ExecutionResult(false, "Name is too short");

        fileSystem.FileRename(_path, _name);

        return new ExecutionResult(true, "File was successfully renamed");
    }
}