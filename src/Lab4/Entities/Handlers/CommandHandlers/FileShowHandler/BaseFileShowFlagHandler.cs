using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileShow;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileShowHandler;

public class BaseFileShowFlagHandler : IFileShowFlagHandler
{
    private IFileShowFlagHandler? _nextHandler;

    public IFileShowFlagHandler SetNext(IFileShowFlagHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual FileShowBuilder? Handle(Iterator request, FileShowBuilder builder)
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