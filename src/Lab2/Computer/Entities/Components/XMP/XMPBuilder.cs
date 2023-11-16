using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.XMP;

public class XMPBuilder
{
    private string? _name;
    private string? _timing;
    private int? _voltage;
    private int? _frequency;

    public XMPBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public XMPBuilder WithTiming(string timing)
    {
        _timing = timing;
        return this;
    }

    public XMPBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public XMPBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XMP Build()
    {
        return new XMP(
            _name ?? throw new ArgumentNullException(),
            _timing ?? throw new ArgumentNullException(),
            _voltage ?? throw new ArgumentNullException(),
            _frequency ?? throw new ArgumentNullException());
    }
}