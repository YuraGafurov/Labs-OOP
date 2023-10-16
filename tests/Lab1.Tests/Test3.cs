using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test3
{
    [Theory]
    [InlineData(100)]
    public void CheckVaklasShouldReturnShipDestroyed(int lengthOfRoute)
    {
        var obstacles = new Collection<BaseObstacle>() { new CosmoWhale() };
        var route = new Collection<BaseSpace>() { new NitrinoParticleSpaceNebulae(lengthOfRoute, obstacles) };
        var vaklas = new Vaklas(false);
        Results result = vaklas.Move(route);
        Assert.Equal(Results.SpaceShipDestroyed, result);
    }

    [Theory]
    [InlineData(100)]
    public void CheckAvgurShouldLostShields(int lengthOfRoute)
    {
        var obstacles = new Collection<BaseObstacle>() { new CosmoWhale() };
        var route = new Collection<BaseSpace>() { new NitrinoParticleSpaceNebulae(lengthOfRoute, obstacles) };
        var avgur = new Avgur(true);
        avgur.Move(route);
        Assert.Null(avgur.Deflector);
    }

    [Theory]
    [InlineData(100)]
    public void CheckMeredianShouldBeUntouched(int lengthOfRoute)
    {
        var obstacles = new Collection<BaseObstacle>() { new CosmoWhale() };
        var route = new Collection<BaseSpace>() { new NitrinoParticleSpaceNebulae(lengthOfRoute, obstacles) };
        var meredian = new Meredian(true);
        meredian.Move(route);
        Assert.Equal(100, meredian.Deflector?.Hp);
    }
}