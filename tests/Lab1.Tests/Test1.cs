using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test1
{
    [Theory]
    [InlineData(200)]
    public void CheckShuttleShouldReturnImpossibility(int lengthOfRoute)
    {
        var obstacles = new Collection<BaseObstacle>();
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        var shuttle = new Shuttle();
        Results result = shuttle.Move(route);
        Assert.Equal(Results.SpaceShipLost, result);
    }

    [Theory]
    [InlineData(200)]
    public void CheckAvgurShouldReturnImpossibility(int lengthOfRoute)
    {
        var obstacles = new Collection<BaseObstacle>();
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        var avgur = new Avgur(false);
        Results result = avgur.Move(route);
        Assert.Equal(Results.SpaceShipLost, result);
    }
}