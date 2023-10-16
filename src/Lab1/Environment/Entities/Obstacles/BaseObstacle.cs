namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public abstract class BaseObstacle
{
    public int? PhysDamage { get; set; }
    public int? EnergyDamage { get; protected set; }
}