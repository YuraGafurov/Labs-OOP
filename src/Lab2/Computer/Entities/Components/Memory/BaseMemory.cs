namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Memory;

public abstract class BaseMemory
{
    protected BaseMemory(string name, int capacity, int operatingSpeed, int powerConsumption)
    {
        Name = name;
        Capacity = capacity;
        OperatingSpeed = operatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public int Capacity { get; }
    public int OperatingSpeed { get; }
    public int PowerConsumption { get; }
}