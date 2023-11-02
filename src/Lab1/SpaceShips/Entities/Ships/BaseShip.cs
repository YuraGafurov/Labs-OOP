using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Ships;

public abstract class BaseShip
{
    protected BaseShip(BaseImpulseEngine impulseEngine, BaseJumpEngine? jumpEngine, ShipArmor.ShipArmor armor, Deflector? deflector)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Armor = armor;
        Deflector = deflector;
    }

    public BaseImpulseEngine ImpulseEngine { get; }
    public BaseJumpEngine? JumpEngine { get; }
    public ShipArmor.ShipArmor Armor { get; }
    public Deflector? Deflector { get; private set; }
    public bool? IsAntiNitrino { get; protected set; }
    public int FuelUsed { get; set; }

    public abstract Results Move(Collection<BaseSpace> route);

    public Results TakeDamage(Collection<IObstacle> obstacles)
    {
        foreach (IObstacle obstacle in obstacles)
        {
            if (IsAntiNitrino.HasValue && obstacle is CosmoWhale)
            {
                continue;
            }

            if (obstacle is IEnergyObstacle)
            {
                if (Deflector?.PhotonDeflector != null)
                {
                    Deflector.TakeDamage(obstacle);
                }
                else
                {
                    return Results.CrewDeath;
                }
            }
            else if (obstacle is IPhysObstacle)
            {
                if (Deflector is null) continue;
                if (!Deflector.TakeDamage(obstacle))
                {
                    Deflector = null;
                    if (obstacle.Damage <= 0) continue;
                    if (!Armor.TakeDamage(obstacle))
                    {
                        return Results.SpaceShipDestroyed;
                    }
                }
                else
                {
                    if (!Armor.TakeDamage(obstacle))
                    {
                        return Results.SpaceShipDestroyed;
                    }
                }
            }
        }

        return Results.Success;
    }
}