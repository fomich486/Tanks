using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public class FourMuzzleWeapon : Weapon
    {
        protected override void Start()
        {
            damage = 1;
            interval = 0.5f/1.5f;
        }
    }
}
