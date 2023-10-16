using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test2
{
    [Theory]
    [InlineData(200)]
    public void CheckVaklasShouldReturnCrewDeath(int lengthOfRoute)
    {
        var obstacles = new Collection<BaseObstacle>() { new AntimatterFlash() };
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        var vaklas = new Vaklas(false);
        Results result = vaklas.Move(route);
        Assert.Equal(Results.CrewDeath, result);
    }

    [Theory]
    [InlineData(200)]
    public void CheckVaklasShouldReturnSuccess(int lengthOfRoute)
    {
        var obstacles = new Collection<BaseObstacle>() { new AntimatterFlash() };
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        var vaklas = new Vaklas(true);
        Results result = vaklas.Move(route);
        Assert.Equal(Results.Success, result);
    }
}