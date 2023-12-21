using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.TreeListHandler;

public class BaseTreeListFlagHandler : ITreeListFlagHandler
{
    private ITreeListFlagHandler? _nextHandler;

    public ITreeListFlagHandler SetNext(ITreeListFlagHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual TreeListBuilder? Handle(Iterator request, TreeListBuilder builder)
    {
        if (_nextHandler is not null)
        {
            return _nextHandler.Handle(request, builder);
        }
        else
        {
            return null;
        }
    }
}