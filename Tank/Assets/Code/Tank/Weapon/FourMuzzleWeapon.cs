using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public class FourMuzzleWeapon : Weapon
    {
        public override void Init(Tank _tank)
        {
            base.Init(_tank);
            damage = 1;
            interval = 0.5f/1.5f;
            Name = "Four";
            Image = Resources.Load<Sprite>(Name) as Sprite;
        }
    }
}
