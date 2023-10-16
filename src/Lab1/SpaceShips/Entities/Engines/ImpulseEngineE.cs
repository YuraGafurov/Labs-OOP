namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;

public class ImpulseEngineE : BaseImpulseEngine
{
    private const int FuelStartCost = 10;
    private const int DefaultFuelConsumption = 3;

    public ImpulseEngineE()
    {
        FuelConsumption = DefaultFuelConsumption;
    }

    public override int FuelCost(int dist)
    {
        return (FuelConsumption * dist) + FuelStartCost;
    }
}