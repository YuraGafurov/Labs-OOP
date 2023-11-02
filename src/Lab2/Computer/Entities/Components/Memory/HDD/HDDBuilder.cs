using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.Components.HDD;

public class HDDBuilder
{
    private string? _name;
    private int? _capacity;
    private int? _spindleRotationSpeed;
    private int? _powerConsumption;

    public HDDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public HDDBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public HDDBuilder WithSpindleRotationSpeed(int speed)
    {
        _spindleRotationSpeed = speed;
        return this;
    }

    public HDDBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public HDD Build()
    {
        return new HDD(
            _name ?? throw new ArgumentNullException(),
            _capacity ?? throw new ArgumentNullException(),
            _spindleRotationSpeed ?? throw new ArgumentNullException(),
            _powerConsumption ?? throw new ArgumentNullException());
    }
}