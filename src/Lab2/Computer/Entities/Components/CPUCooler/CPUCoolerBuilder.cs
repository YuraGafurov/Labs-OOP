using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.CPUCooler;

public class CPUCoolerBuilder
{
    private readonly ICollection<Sockets>? _supportedSockets;
    private string? _name;
    private Size? _size;
    private int? _thermalDesignPower;

    public CPUCoolerBuilder()
    {
        _supportedSockets = new List<Sockets>();
    }

    public CPUCoolerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CPUCoolerBuilder WithSize(Size? size)
    {
        _size = size;
        return this;
    }

    public CPUCoolerBuilder WithTDP(int power)
    {
        _thermalDesignPower = power;
        return this;
    }

    public CPUCoolerBuilder AddSocket(Sockets socket)
    {
        _supportedSockets?.Add(socket);
        return this;
    }

    public CPUCooler Build()
    {
        return new CPUCooler(
            _name ?? throw new ArgumentNullException(),
            _size ?? throw new ArgumentNullException(),
            _supportedSockets ?? throw new ArgumentNullException(),
            _thermalDesignPower ?? throw new ArgumentNullException());
    }
}