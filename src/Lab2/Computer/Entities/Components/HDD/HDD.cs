namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.HDD;

public class HDD
{
    public HDD(string name, int capacity, int spindleRotationSpeed, int powerConsumption)
    {
        Name = name;
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public int Capacity { get; set; }
    public int SpindleRotationSpeed { get; set; }
    public int PowerConsumption { get; set; }

    public HDDBuilder Direct(HDDBuilder builder)
    {
        builder.WithName(Name)
            .WithCapacity(Capacity)
            .WithSpindleRotationSpeed(SpindleRotationSpeed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}