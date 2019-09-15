using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class PlayerTank : Tank
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

        protected override void Die()
        {
            throw new System.NotImplementedException();
        }

    }
}
