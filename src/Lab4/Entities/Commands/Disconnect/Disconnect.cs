using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Disconnect;

public class Disconnect : ICommand
{
    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        fileSystem.Disconnect();
        return new ExecutionResult(true, "File system disconnected");
    }
}