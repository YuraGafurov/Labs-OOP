using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeList;

public class TreeList : ICommand
{
    private int _depth;

    public TreeList(int depth)
    {
        _depth = depth;
    }

    public ExecutionResult Execute(IFileSystem fileSystem)
    {
        if (_depth < 1) return new ExecutionResult(false, "Depth is too small");
        fileSystem.TreeList(_depth);
        return new ExecutionResult(true, "Command was completed successfully");
    }
}