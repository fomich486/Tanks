using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public class SimpleWeapon : Weapon
    {
        float interval = 1f;
        float nextSpawn = 0;
        private void Start()
        {
            damage = 1;
        }

        public override void Use()
        {
            if (Time.time > nextSpawn)
            {
                base.Use();
                nextSpawn = Time.time + interval;
            }
        }
    }
}
