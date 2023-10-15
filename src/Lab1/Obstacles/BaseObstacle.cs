namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class BaseObstacle
{
    public int? PhysDamage { get; set; }
    public int? EnergyDamage { get; protected set; }
}