using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

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
        }

        if (isPhotonic)
        {
            PhotonDeflector = new PhotonDeflector();
        }
    }

    public PhotonDeflector? PhotonDeflector { get; set; }
    public int Hp { get; protected set; }

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