using System.Runtime.CompilerServices;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities.Deflectors;

public class Deflector
{
    public Deflector(TypesOfDeflectors type, bool isPhotonic)
    {
        switch (type)
        {
            case TypesOfDeflectors.DeflectorClass1:
                Hp = 20;
                break;
            case TypesOfDeflectors.DeflectorClass2:
                Hp = 100;
                break;
            case TypesOfDeflectors.DeflectorClass3:
                Hp = 400;
                break;
            default:
                throw new SwitchExpressionException("Invalid type of deflector");
        }

        if (isPhotonic)
        {
            PhotonDeflector = new PhotonDeflector();
        }
    }

    public PhotonDeflector? PhotonDeflector { get; private set; }
    public int Hp { get; private set; }

    public void TakeDamage(BaseObstacle obstacle)
    {
        if (obstacle.EnergyDamage.HasValue)
        {
            PhotonDeflector?.TakeDamage();
            if (PhotonDeflector?.Hp == 0)
            {
                PhotonDeflector = null;
            }
        }

        if (obstacle.PhysDamage.HasValue)
        {
            Hp -= obstacle.PhysDamage.Value;
        }
    }
}