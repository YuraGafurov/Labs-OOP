using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.TreeListHandler;

public class TreeListDepthHandler : BaseTreeListFlagHandler
{
    public override TreeListBuilder? Handle(Iterator request, TreeListBuilder builder)
    {
        if (request.Current() is not "-d" || !request.MoveNext()) return base.Handle(request, builder);
        builder.WithDepth(int.Parse(request.Current(), new NumberFormatInfo()));
        return builder;
    }
}