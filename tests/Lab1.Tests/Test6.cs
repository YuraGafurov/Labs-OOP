using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test6
{
    [Fact]
    public void CheckOptimalShipShouldBeVaklas()
    {
        var obstacles = new Collection<BaseObstacle>() { };
        int lengthOfRoute = 50;
        var route = new Collection<BaseSpace>() { new NitrinoParticleSpaceNebulae(lengthOfRoute, obstacles) };
        BaseShip shuttle = new Shuttle();
        BaseShip vaklas = new Vaklas(false);
        var ships = new Collection<BaseShip>() { shuttle, vaklas };
        BaseShip? optimalShip = ChooseTheOptimalShip.ChooseShip(ships, route);
        Assert.Equal(vaklas, optimalShip);
    }
}