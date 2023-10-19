namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class CosmoWhale : IPhysObstacle
{
    private const int DefaultDamage = 400;

    public int Damage { get; set; } = DefaultDamage;
}