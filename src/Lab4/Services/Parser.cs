using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.ConnectHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileShowHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.TreeListHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class Parser
{
    private readonly ConnectHandler _connectHandler = new ConnectHandler(new ConnectModeHandler());
    private readonly DisconnectHandler _disconnectHandler = new DisconnectHandler();
    private readonly FileCopyHandler _fileCopyHandler = new FileCopyHandler();
    private readonly FileDeleteHandler _fileDeleteHandler = new FileDeleteHandler();
    private readonly FileMoveHandler _fileMoveHandler = new FileMoveHandler();
    private readonly FileRenameHandler _fileRenameHandler = new FileRenameHandler();
    private readonly FileShowHandler _fileShowHandler = new FileShowHandler(new FileShowModeHandler());
    private readonly TreeGotoHandler _treeGotoHandler = new TreeGotoHandler();
    private readonly TreeListHandler _treeListHandler = new TreeListHandler(new TreeListDepthHandler());

    public Parser()
    {
        _connectHandler.SetNext(_disconnectHandler).SetNext(_fileCopyHandler).SetNext(_fileDeleteHandler)
            .SetNext(_fileMoveHandler).SetNext(_fileRenameHandler).SetNext(_fileShowHandler)
            .SetNext(_treeGotoHandler).SetNext(_treeListHandler);
    }

    public ICommand? Parse(string request)
    {
        var iterator = new Iterator(request);
        return _connectHandler.Handle(iterator);
    }
}