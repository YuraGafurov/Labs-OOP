using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class FileCopy : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileCopy(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        if (!Path.Exists(_sourcePath) || !Path.Exists(_destinationPath))
            return new ExecutionResult(false, "Path does not exist");

        fileSystem.FileCopy(_sourcePath, _destinationPath);

        return new ExecutionResult(true, "File was successfully copied");
    }
}