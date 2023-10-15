namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public abstract class BaseImpulseEngine
{
    public int FuelConsumption { get; set; }
    public abstract int FuelCost(int dist);
}