using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileShow;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileShowHandler;

public class FileShowModeHandler : BaseFileShowFlagHandler
{
    public override FileShowBuilder? Handle(Iterator request, FileShowBuilder builder)
    {
        if (request.Current() is not "-m" || !request.MoveNext()) return base.Handle(request, builder);
        builder.WithMode(request.Current());
        return builder;
    }
}