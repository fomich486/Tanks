using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tanks
{
    [RequireComponent(typeof(Controlls.InputController))]
    public class PlayerTank : Tank,IPlayerComunicator
    {
        public Weapons.Weapon CurrentWeapon
        {
            get => currentWeapon;
        }

        public Vector3 Position => transform.position;

        public float Speed => speed;

        public override void Die()
        {
            GameController.Instance.Attemp -= 1;
            base.Die();
        }

        protected override void InitValues()
        {
            maxArmor = 20;
            speed = 5f;
            weaponType = FactorySpace.WeaponsTypes.Double -1;
            MaterialName = "White";
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

        protected override void SpawnTower()
        {
            base.SpawnTower();
            HUD.Instance.SetaWeaponName(currentWeapon.Name);
            HUD.Instance.SetWeaponImage(currentWeapon.Image);
        }
    }
}
