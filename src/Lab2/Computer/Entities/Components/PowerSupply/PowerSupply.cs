namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.PowerSupply;

public class PowerSupply
{
    public PowerSupply(string name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public string Name { get; set; }
    public int PeakLoad { get; set; }
}