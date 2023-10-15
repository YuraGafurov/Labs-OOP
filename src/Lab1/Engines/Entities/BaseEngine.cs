namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public abstract class BaseEngine
{
    private const int DefaultFuelQuantity = 1000;

    protected BaseEngine()
    {
        Fuel = DefaultFuelQuantity;
    }

    public int Fuel { get; set; }
    public int FuelConsumption { get; set; }
    public abstract int FuelCost(int dist);
}