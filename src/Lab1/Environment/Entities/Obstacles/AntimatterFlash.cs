namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class AntimatterFlash : IEnergyObstacle
{
    private const int DefaultDamage = 1;

    public int Damage { get; set; } = DefaultDamage;
}