using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    [Theory]
    [InlineData(200)]
    public void CheckShuttleAndAvgurShouldReturnImpossibility(int lengthOfRoute)
    {
        var obstacles = new Collection<IObstacle>();
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        var shuttle = new Shuttle();
        var avgur = new Avgur(false);
        Results resultShuttle = shuttle.Move(route);
        Results resultAvgur = avgur.Move(route);
        Assert.Equal(Results.SpaceShipLost, resultShuttle);
        Assert.Equal(Results.SpaceShipLost, resultAvgur);
    }

    [Theory]
    [InlineData(200)]
    public void CheckVaklasWithAntimatterFlash(int lengthOfRoute)
    {
        var obstacles = new Collection<IObstacle>() { new AntimatterFlash() };
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        var vaklas = new Vaklas(false);
        var vaklasP = new Vaklas(true);
        Results result = vaklas.Move(route);
        Results resultP = vaklasP.Move(route);
        Assert.Equal(Results.CrewDeath, result);
        Assert.Equal(Results.Success, resultP);
    }

    [Theory]
    [InlineData(100)]
    public void CheckShipsWithCosmoWhale(int lengthOfRoute)
    {
        var obstacles = new Collection<IObstacle>() { new CosmoWhale() };
        var route = new Collection<BaseSpace>() { new NitrinoParticleSpaceNebulae(lengthOfRoute, obstacles) };
        var vaklas = new Vaklas(false);
        var avgur = new Avgur(true);
        var meredian = new Meredian(true);
        Results result = vaklas.Move(route);
        route[0].Obstacles[0].Damage = 400;
        avgur.Move(route);
        meredian.Move(route);
        Assert.Equal(Results.SpaceShipDestroyed, result);
        Assert.Null(avgur.Deflector);
        Assert.Equal(100, meredian.Deflector?.Hp);
    }

    [Fact]
    public void CheckOptimalShipShouldBeShuttle()
    {
        var obstacles = new Collection<IObstacle>() { };
        int lengthOfRoute = 50;
        var route = new Collection<BaseSpace>() { new NormalSpace(lengthOfRoute, obstacles) };
        BaseShip shuttle = new Shuttle();
        BaseShip vaklas = new Vaklas(false);
        var ships = new Collection<BaseShip>() { shuttle, vaklas };
        BaseShip? optimalShip = ChooseTheOptimalShip.ChooseShip(ships, route);
        Assert.Equal(shuttle, optimalShip);
    }

    [Fact]
    public void CheckOptimalShipShouldBeStella()
    {
        var obstacles = new Collection<IObstacle>() { };
        int lengthOfRoute = 200;
        var route = new Collection<BaseSpace>() { new HighDensitySpaceNebulae(lengthOfRoute, obstacles) };
        BaseShip avgur = new Avgur(false);
        BaseShip stella = new Stella(false);
        var ships = new Collection<BaseShip>() { avgur, stella };
        BaseShip? optimalShip = ChooseTheOptimalShip.ChooseShip(ships, route);
        Assert.Equal(stella, optimalShip);
    }

    [Fact]
    public void CheckOptimalShipShouldBeVaklas()
    {
        var obstacles = new Collection<IObstacle>() { };
        int lengthOfRoute = 50;
        var route = new Collection<BaseSpace>() { new NitrinoParticleSpaceNebulae(lengthOfRoute, obstacles) };
        BaseShip shuttle = new Shuttle();
        BaseShip vaklas = new Vaklas(false);
        var ships = new Collection<BaseShip>() { shuttle, vaklas };
        BaseShip? optimalShip = ChooseTheOptimalShip.ChooseShip(ships, route);
        Assert.Equal(vaklas, optimalShip);
    }
}