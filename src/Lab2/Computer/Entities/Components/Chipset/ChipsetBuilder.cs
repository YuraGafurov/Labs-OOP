using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Chipset;

public class ChipsetBuilder
{
    private readonly ICollection<int>? _availableMemoryFrequencies;
    private string? _name;
    private bool? _supportXMP;

    public ChipsetBuilder()
    {
        _availableMemoryFrequencies = new List<int>();
    }

    public ChipsetBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ChipsetBuilder WithXMP()
    {
        _supportXMP = true;
        return this;
    }

    public ChipsetBuilder AddMemoryFrequency(int frequency)
    {
        _availableMemoryFrequencies?.Add(frequency);
        return this;
    }

    public Chipset Build()
    {
        return new Chipset(
            _name ?? throw new ArgumentNullException(),
            _supportXMP ?? throw new ArgumentNullException(),
            _availableMemoryFrequencies ?? throw new ArgumentNullException());
    }
}