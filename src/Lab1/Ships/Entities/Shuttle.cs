using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipArmor;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Shuttle : BaseShip
{
    public Shuttle()
        : base(new ImpulseEngineC(), null, new ShipArmor(TypesOfArmor.ArmorClass1), null)
    {
    }

    public override Results Move(Collection<BaseSpace> route)
    {
        foreach (BaseSpace space in route)
        {
            switch (space)
            {
                case NormalSpace:
                    FuelUsed += ImpulseEngine.FuelCost(space.Length);
                    break;
                case HighDensitySpaceNebulae:
                    return Results.SpaceShipLost;
                case NitrinoParticleSpaceNebulae:
                    FuelUsed += ImpulseEngine.FuelCost(space.Length) * 3;
                    break;
            }

            if (TakeDamage(space.Obstacles) != Results.Success)
            {
                return TakeDamage(space.Obstacles);
            }
        }

        return Results.Success;
    }
}