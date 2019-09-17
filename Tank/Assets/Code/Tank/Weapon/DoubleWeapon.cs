using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public class DoubleWeapon : Weapon
    {
        public override void Init(Tank _tank)
        {
            base.Init(_tank);
            damage = 2;
            //interval = 0.15f;
            interval = 1.15f;
            Name = "Double Weapon";
            Image = Resources.Load<Sprite>(Name);
        }
    }
}
