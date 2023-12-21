using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.TreeListHandler;

public interface ITreeListFlagHandler
{
    ITreeListFlagHandler SetNext(ITreeListFlagHandler handler);

    TreeListBuilder? Handle(Iterator request, TreeListBuilder builder);
}