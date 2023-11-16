using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPU;

public class CPUBuilder
{
    private readonly ICollection<int>? _supportedMemoryFrequencies;
    private string? _name;
    private int? _coreFrequency;
    private int? _coreCount;
    private Sockets? _socket;
    private bool? _hasVideocore;
    private int? _thermalDesignPower;
    private int? _powerConsumption;

    public CPUBuilder()
    {
        _supportedMemoryFrequencies = new List<int>();
    }

    public CPUBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CPUBuilder WithCoreFrequency(int frequency)
    {
        _coreFrequency = frequency;
        return this;
    }

    public CPUBuilder WithCoreCount(int count)
    {
        _coreCount = count;
        return this;
    }

    public CPUBuilder WithSocket(Sockets socket)
    {
        _socket = socket;
        return this;
    }

    public CPUBuilder WithVideocore()
    {
        _hasVideocore = true;
        return this;
    }

    public CPUBuilder WithTDP(int tdp)
    {
        _thermalDesignPower = tdp;
        return this;
    }

    public CPUBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public CPUBuilder AddMemoryFrequency(int frequency)
    {
        _supportedMemoryFrequencies?.Add(frequency);
        return this;
    }

    public CPU Build()
    {
        return new CPU(
            _name ?? throw new ArgumentNullException(),
            _coreFrequency ?? throw new ArgumentNullException(),
            _coreCount ?? throw new ArgumentNullException(),
            _socket ?? throw new ArgumentNullException(),
            _hasVideocore ?? throw new ArgumentNullException(),
            _supportedMemoryFrequencies ?? throw new ArgumentNullException(),
            _thermalDesignPower ?? throw new ArgumentNullException(),
            _powerConsumption ?? throw new ArgumentNullException());
    }
}