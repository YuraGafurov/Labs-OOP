using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class BaseSpace
{
    protected BaseSpace(int length)
    {
        Length = length;
        Obstacles = new Collection<BaseObstacle>();
    }

    public int Length { get; set; }
    public Collection<BaseObstacle> Obstacles { get; }
}