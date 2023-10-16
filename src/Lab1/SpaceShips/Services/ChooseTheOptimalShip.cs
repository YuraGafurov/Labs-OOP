using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Services;

public static class ChooseTheOptimalShip
{
    public static BaseShip? ChooseShip(Collection<BaseShip> ships, Collection<BaseSpace> route)
    {
        BaseShip? optimalShip = null;
        foreach (BaseShip ship in ships)
        {
            if (ship.Move(route) != Results.Success) continue;
            if (optimalShip == null)
            {
                optimalShip = ship;
                continue;
            }

            if (ship.FuelUsed < optimalShip.FuelUsed)
            {
                optimalShip = ship;
            }
        }

        return optimalShip;
    }
}