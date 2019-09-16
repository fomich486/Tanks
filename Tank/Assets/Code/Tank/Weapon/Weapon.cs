using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        private Tank tankToFollow;

        public bool canShoot = true;
        [SerializeField]
        protected int damage;
        [SerializeField]
        protected List<Transform> muzzles;

        public void Init(Tank _tank)
        {
            tankToFollow = _tank;
        }

        public virtual void Use()
        {
            GameObject _projectile = Resources.Load("Projectile") as GameObject;
            foreach (var _muzzle in muzzles)
            {
                Projectile _p = Instantiate(_projectile.GetComponent<Projectile>(), _muzzle.position, Quaternion.identity) as Projectile;
                _p.Init(damage, transform.forward);
            }
        }

        private void Update()
        {
            FollowTank();
        }

        private void FollowTank()
        {
            transform.position = tankToFollow.TowerPosition;
        }
    }
}
