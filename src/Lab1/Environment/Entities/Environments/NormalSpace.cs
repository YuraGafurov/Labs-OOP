using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;

public class NormalSpace : BaseSpace
{
    public NormalSpace(int length, Collection<IObstacle> obstacles)
    : base(length)
    {
        IEnumerable<IObstacle> selectedObstacles = obstacles.Where(obst => obst is Asteroid or Meteor);
        foreach (IObstacle obstacle in selectedObstacles)
        {
            Obstacles.Add(obstacle);
        }
    }
}