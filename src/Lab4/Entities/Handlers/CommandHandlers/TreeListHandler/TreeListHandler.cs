using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.TreeListHandler;

public class TreeListHandler : BaseHandler
{
    private TreeListDepthHandler _depthHandler;

    public TreeListHandler(TreeListDepthHandler depthHandler)
    {
        _depthHandler = depthHandler;
    }

    public override ICommand? Handle(Iterator request)
    {
        string tmpRequest = request.Current() + " ";
        if (!request.MoveNext()) return base.Handle(request);
        tmpRequest += request.Current();
        if (tmpRequest is not "tree list" || !request.MoveNext()) return base.Handle(request);
        var builder = new TreeListBuilder();
        builder = _depthHandler.Handle(request, builder);
        while (request.MoveNext())
        {
            if (builder != null) builder = _depthHandler.Handle(request, builder);
        }

        return builder?.Build();
    }
}