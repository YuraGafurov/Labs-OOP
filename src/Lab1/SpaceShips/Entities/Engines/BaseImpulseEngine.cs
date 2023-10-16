namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;

public abstract class BaseImpulseEngine
{
    public int FuelConsumption { get; protected set; }
    public abstract int FuelCost(int dist);
}