using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public class SimpleWeapon : Weapon
    {

        public override void Init(Tank _tank)
        {
            base.Init(_tank);
            damage = 1;
            interval = 0.5f;
            Name = "Simple Weapon";
            Image = Resources.Load<Sprite>(Name);
            if (Image == null)
            {
                print("ALLARM!@");
            }
        }
    }
}
