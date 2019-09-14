using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        //projectile
        [SerializeField]
        private Transform muzzles;
        public abstract void Use();
    }
}
