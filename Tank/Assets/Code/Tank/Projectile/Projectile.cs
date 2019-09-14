using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapon
{
    public class Projectile : MonoBehaviour
    {
        protected int damage;

        public void Init(int _damage)
        {
            damage = _damage;
        }

        public void OnCollisionEnter(Collision collision)
        {
            
        }
    }
}
