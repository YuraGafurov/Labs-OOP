using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileShow;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileShowHandler;

public interface IFileShowFlagHandler
{
    IFileShowFlagHandler SetNext(IFileShowFlagHandler handler);

    FileShowBuilder? Handle(Iterator request, FileShowBuilder builder);
}