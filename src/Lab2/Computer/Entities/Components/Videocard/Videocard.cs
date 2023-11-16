namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Videocard;

public class Videocard
{
    public Videocard(string name, int length, int width, int availableMemorySize, int versionOfPci, int chipFrequency, int powerConsumption)
    {
        Name = name;
        Length = length;
        Width = width;
        AvailableMemorySize = availableMemorySize;
        VersionOfPCI = versionOfPci;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int AvailableMemorySize { get; set; }
    public int VersionOfPCI { get; set; }
    public int ChipFrequency { get; set; }
    public int PowerConsumption { get; set; }

    public VideocardBuilder Direct(VideocardBuilder builder)
    {
        builder.WithName(Name)
            .WithLength(Length)
            .WithWidth(Width)
            .WithAvailableMemorySize(AvailableMemorySize)
            .WithPCIVersion(VersionOfPCI)
            .WithChipFrequency(ChipFrequency)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}