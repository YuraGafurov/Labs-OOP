using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.BIOS;

public class BIOSBuilder
{
    private readonly ICollection<CPU.CPU>? _supportedProcessors;
    private string? _name;
    private BIOSType? _type;
    private int? _version;

    public BIOSBuilder()
    {
        _supportedProcessors = new List<CPU.CPU>();
    }

    public BIOSBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public BIOSBuilder WithType(BIOSType type)
    {
        _type = type;
        return this;
    }

    public BIOSBuilder WithVersion(int version)
    {
        _version = version;
        return this;
    }

    public BIOSBuilder AddProcessor(CPU.CPU processor)
    {
        _supportedProcessors?.Add(processor);
        return this;
    }

    public BIOS Build()
    {
        return new BIOS(
            _name ?? throw new ArgumentNullException(),
            _type ?? throw new ArgumentNullException(),
            _version ?? throw new ArgumentNullException(),
            _supportedProcessors ?? throw new ArgumentNullException());
    }
}