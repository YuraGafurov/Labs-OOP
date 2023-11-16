using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Chipset;

public class Chipset
{
    public Chipset(string name, bool xmp, ICollection<int> availableMemoryFrequencies)
    {
        Name = name;
        SupportXMP = xmp;
        AvailableMemoryFrequencies = availableMemoryFrequencies;
    }

    public string Name { get; set; }
    public bool SupportXMP { get; }
    public ICollection<int> AvailableMemoryFrequencies { get; }

    public ChipsetBuilder Direct(ChipsetBuilder builder)
    {
        builder.WithName(Name);
        if (SupportXMP)
        {
            builder.WithXMP();
        }

        foreach (int frequency in AvailableMemoryFrequencies)
        {
            builder.AddMemoryFrequency(frequency);
        }

        return builder;
    }
}