using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    //TODO: Make comunication Interface for gamecontroller
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
        }

        protected override void SpawnTower()
        {
            TowerName = "Tower3";
            base.SpawnTower();
        }
    }
}
