using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.ComputerCase;

public class ComputerCase
{
    public ComputerCase(string name, CaseSizes size, int maximumLengthOfVideocard, int maximumWidthOfVideocard, ICollection<MotherboardFormFactors> supportedMotherboardFormFactors)
    {
        Name = name;
        Size = size;
        MaximumLengthOfVideocard = maximumLengthOfVideocard;
        MaximumWidthOfVideocard = maximumWidthOfVideocard;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
    }

    public string Name { get; set; }
    public CaseSizes Size { get; set; }
    public int MaximumLengthOfVideocard { get; set; }
    public int MaximumWidthOfVideocard { get; set; }
    public ICollection<MotherboardFormFactors> SupportedMotherboardFormFactors { get; }

    public ComputerCaseBuilder Direct(ComputerCaseBuilder builder)
    {
        builder.WithName(Name)
            .WithSize(Size)
            .WithMaximumVideocardLength(MaximumLengthOfVideocard)
            .WithMaximumVideocardWidth(MaximumWidthOfVideocard);

        foreach (MotherboardFormFactors formFactor in SupportedMotherboardFormFactors)
        {
            builder.AddMotherboardFormFactor(formFactor);
        }

        return builder;
    }
}