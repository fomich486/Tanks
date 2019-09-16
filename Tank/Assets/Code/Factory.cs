using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks;

namespace FactorySpace
{
    public abstract class Factory 
    {
        public abstract ISpawnable GetProduct(int _Type);
    }

    public class TankFactory : Factory
    {
        public override ISpawnable GetProduct(int _tankType)
        {
            GameObject _tankSpawned = Resources.Load("tank") as GameObject;

            int x = (int)Random.Range(-GameController.Instance.MapSize.x / 2, GameController.Instance.MapSize.x / 2);
            int z = (int)Random.Range(-GameController.Instance.MapSize.y / 2, GameController.Instance.MapSize.y / 2);
            Vector3 _spawnPosition = new Vector3(x, _tankSpawned.transform.localScale.y / 2, z);
            if (_tankType == (int)TankTypes.Player)
            {
                _spawnPosition = Vector3.up * _tankSpawned.transform.localScale.y / 2;
            }

            GameObject _newTank = MonoBehaviour.Instantiate(_tankSpawned, _spawnPosition, Quaternion.identity);
            Tank _tank;
            switch (_tankType)
            {
                case (int)TankTypes.GreenEnemy:
                     _tank =_newTank.AddComponent(typeof(GreenEnemyTank)) as Tank;
                     break;
                case (int)TankTypes.YellowEnemy:
                     _tank = _newTank.AddComponent(typeof(YellowEnemyTank)) as Tank;
                     break;
                case (int)TankTypes.RedEnemy:
                     _tank = _newTank.AddComponent(typeof(RedEnemyTank)) as Tank;
                     break;  
                case (int)TankTypes.Player:
                     _tank = _newTank.AddComponent(typeof(PlayerTank)) as Tank;
                    break;
                default:
                    return null;
            }
            return _tank.GetComponent<ISpawnable>();
        }
    }

    public class WeaponFactory : Factory
    {
        public override ISpawnable GetProduct(int _weaponType)
        {
            Debug.Log("Path is == " + "Tower" + _weaponType.ToString());
            GameObject _weaponSpawned = Resources.Load("Tower" + _weaponType.ToString()) as GameObject;
            _weaponSpawned = MonoBehaviour.Instantiate(_weaponSpawned) as GameObject;
            return _weaponSpawned.GetComponent<ISpawnable>();
        }
    }

    public class FactoryProducer
    {
        public static Factory GetFactory(FactoryProductType _type)
        {
            switch (_type) {
                case FactoryProductType.Tanks:
                    return new TankFactory();
                case FactoryProductType.Weapons:
                    return new WeaponFactory();
                default:
                    return null;
            }
        }
    }

    public enum TankTypes
    {
        GreenEnemy,YellowEnemy,RedEnemy, Player 
    }

    public enum WeaponsTypes
    {
        Simple,Double,FourMuzzle
    }

    public enum FactoryProductType
    {
        Tanks,Weapons
    }
}
