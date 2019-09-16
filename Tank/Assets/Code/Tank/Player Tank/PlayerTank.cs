using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(Controlls.InputController))]
    public class PlayerTank : Tank,IPlayerComunicator
    {
        public Weapons.Weapon CurrentWeapon
        {
            get => currentWeapon;
        }
        public override Vector3 CurrentDirection
        {
            get => currentDirection;
            set
            {
                if (value == Vector3.right || value == Vector3.left || value == Vector3.forward || value == Vector3.back || value == Vector3.zero )
                    {
                    currentDirection = value;
                }
                else
                    return;
            }
        }

        public Vector3 Position => transform.position;

        public float UpdateRate => updateDelay;

        public override void Die()
        {
            base.Die();
        }

        protected override void InitValues()
        {
            maxArmor = 20;
            updateDelay = 0.25f;
            weaponType = FactorySpace.WeaponsTypes.Double -1;
        }

        //TODO: Change this part on factory
        public void NextWeapon()
        {
            if ((int)weaponType < 2)
            {
               weaponType = weaponType + 1;
            }
            else
            {
                weaponType =FactorySpace.WeaponsTypes.Simple;
            }
            Destroy(currentWeapon.gameObject);
            SpawnTower();
        }

        public void PrevWeapon()
        {
            if ((int)weaponType > 0)
            {
                weaponType = weaponType - 1;
            }
            else
            {
                weaponType =FactorySpace.WeaponsTypes.FourMuzzle;
            }
            Destroy(currentWeapon.gameObject);
            SpawnTower();
        }
    }
}
