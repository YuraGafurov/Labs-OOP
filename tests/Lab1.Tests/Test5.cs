using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test5
{
    [Fact]
    public void CheckOptimalShipShouldBeStella()
    {
        var obstacles = new Collection<BaseObstacle>() { };
        int lengthOfRoute = 200;
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        BaseShip avgur = new Avgur(false);
        BaseShip stella = new Stella(false);
        var ships = new Collection<BaseShip>() { avgur, stella };
        BaseShip? optimalShip = ChooseTheOptimalShip.ChooseShip(ships, route);
        Assert.Equal(stella, optimalShip);
    }
}