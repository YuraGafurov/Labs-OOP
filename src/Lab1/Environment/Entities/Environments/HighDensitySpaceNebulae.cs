using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;

public class HighDensitySpaceNebulae : BaseSpace
{
    public HighDensitySpaceNebulae(int length, Collection<IObstacle> obstacles)
        : base(length)
    {
        foreach (IObstacle obstacle in obstacles.Where(obst => obst is AntimatterFlash))
        {
            Obstacles.Add(obstacle);
        }
    }
}