using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public class DoubleWeapon : Weapon
    {
        protected override void Start()
        {
            damage = 2;
            interval = 0.15f;
        }
    }
}
