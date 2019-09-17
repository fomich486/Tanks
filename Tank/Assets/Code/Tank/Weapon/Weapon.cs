using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public abstract class Weapon : MonoBehaviour,ISpawnable
    {
        public string Name;
        public Sprite Image;

        private Tank tankToFollow;

        protected float interval = 1f;
        private float nextSpawn = 0;
        public bool canShoot = true;

        [SerializeField]
        protected int damage;
        [SerializeField]
        protected List<Transform> muzzles;

        public Transform Type =>transform;

        public virtual void Init(Tank _tank)
        {
            tankToFollow = _tank;
            FollowTank();
        }

        public virtual void Use()
        {
            if (Time.time > nextSpawn)
            {
                SpawnProjectile();
                nextSpawn = Time.time + interval;
            }
        }

        protected void SpawnProjectile()
        {
            GameObject _projectile = Resources.Load("Projectile") as GameObject;
            foreach (var _muzzle in muzzles)
            {
                Projectile _p = Instantiate(_projectile.GetComponent<Projectile>(), _muzzle.position, Quaternion.identity) as Projectile;
                _p.Init(damage, _muzzle.up);
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
