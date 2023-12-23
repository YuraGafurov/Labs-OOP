using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers;

public interface IHandler
{
    IHandler SetNext(IHandler handler);

    ICommand? Handle(Iterator request);
}