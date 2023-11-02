namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.XMP;

public class XMP
{
    public XMP(string name, string timing, int voltage, int frequency)
    {
        Name = name;
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Name { get; set; }
    public string Timing { get; set; }
    public int Voltage { get; set; }
    public int Frequency { get; set; }

    public XMPBuilder Direct(XMPBuilder builder)
    {
        builder.WithName(Name)
            .WithTiming(Timing)
            .WithVoltage(Voltage)
            .WithFrequency(Frequency);

        return builder;
    }
}