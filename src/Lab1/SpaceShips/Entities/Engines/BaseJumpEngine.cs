namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;

public abstract class BaseJumpEngine
{
    public int FuelConsumption { get; set; }
    public int RangeOfTravel { get; protected set; }

    public abstract int FuelCost(int dist);
}