using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.Videocard;

public class VideocardBuilder
{
    private string? _name;
    private int? _length;
    private int? _width;
    private int? _availableMemorySize;
    private int? _versionOfPCI;
    private int? _chipFrequency;
    private int? _powerConsumption;

    public VideocardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public VideocardBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public VideocardBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public VideocardBuilder WithAvailableMemorySize(int size)
    {
        _availableMemorySize = size;
        return this;
    }

    public VideocardBuilder WithPCIVersion(int version)
    {
        _versionOfPCI = version;
        return this;
    }

    public VideocardBuilder WithChipFrequency(int frequency)
    {
        _chipFrequency = frequency;
        return this;
    }

    public VideocardBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public Videocard Build()
    {
        return new Videocard(
            _name ?? throw new ArgumentNullException(),
            _length ?? throw new ArgumentNullException(),
            _width ?? throw new ArgumentNullException(),
            _availableMemorySize ?? throw new ArgumentNullException(),
            _versionOfPCI ?? throw new ArgumentNullException(),
            _chipFrequency ?? throw new ArgumentNullException(),
            _powerConsumption ?? throw new ArgumentNullException());
    }
}