using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;

public class NitrinoParticleSpaceNebulae : BaseSpace
{
    public NitrinoParticleSpaceNebulae(int length, Collection<IObstacle> obstacles)
        : base(length)
    {
        IEnumerable<IObstacle> selectedObstacles = obstacles.Where(obst => obst is CosmoWhale);
        foreach (IObstacle obstacle in selectedObstacles)
        {
            Obstacles.Add(obstacle);
        }
    }
}