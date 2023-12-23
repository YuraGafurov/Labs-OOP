using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileShow;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileShowHandler;

public class FileShowHandler : BaseHandler
{
    private FileShowModeHandler _modeHandler;

    public FileShowHandler(FileShowModeHandler modeHandler)
    {
        _modeHandler = modeHandler;
    }

    public override ICommand? Handle(Iterator request)
    {
        string tmpRequest = request.Current() + " ";
        if (!request.MoveNext()) return base.Handle(request);
        tmpRequest += request.Current();
        if (tmpRequest is not "file show" || !request.MoveNext()) return base.Handle(request);
        var builder = new FileShowBuilder();
        builder = builder.WithPath(request.Current());
        if (!request.MoveNext()) return base.Handle(request);
        builder = _modeHandler.Handle(request, builder);
        while (request.MoveNext())
        {
            if (builder != null) builder = _modeHandler.Handle(request, builder);
        }

        return builder?.Build();
    }
}