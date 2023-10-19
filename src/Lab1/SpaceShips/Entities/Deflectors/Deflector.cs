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

    public bool TakeDamage(IObstacle obstacle)
    {
        if (obstacle is IEnergyObstacle)
        {
            PhotonDeflector?.TakeDamage();
            if (PhotonDeflector?.Hp == 0)
            {
                PhotonDeflector = null;
            }

            return true;
        }
        else
        {
            Hp -= obstacle.Damage;
            if (Hp > 0)
            {
                return true;
            }
            else if (Hp == 0)
            {
                return false;
            }
            else
            {
                obstacle.Damage -= Hp;
                return false;
            }
        }
    }
}