using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test4
{
    [Fact]
    public void CheckOptimalShipShouldBeShuttle()
    {
        var obstacles = new Collection<BaseObstacle>() { };
        int lengthOfRoute = 50;
        var route = new Collection<BaseSpace>() { new NormalSpace(lengthOfRoute, obstacles) };
        BaseShip shuttle = new Shuttle();
        BaseShip vaklas = new Vaklas(false);
        var ships = new Collection<BaseShip>() { shuttle, vaklas };
        BaseShip? optimalShip = ChooseTheOptimalShip.ChooseShip(ships, route);
        Assert.Equal(shuttle, optimalShip);
    }
}