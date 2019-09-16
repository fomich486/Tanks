﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public abstract class Weapon : MonoBehaviour,ISpawnable
    {
        private Tank tankToFollow;

        protected float interval = 1f;
        private float nextSpawn = 0;
        public bool canShoot = true;

        [SerializeField]
        protected int damage;
        [SerializeField]
        protected List<Transform> muzzles;

        public Transform Type =>transform;

        protected abstract void Start();

        public void Init(Tank _tank)
        {
            tankToFollow = _tank;
            FollowTank();
        }

        public virtual void Use()
        {
            if (Time.time > nextSpawn)
            {
                GameObject _projectile = Resources.Load("Projectile") as GameObject;
                foreach (var _muzzle in muzzles)
                {
                Projectile _p = Instantiate(_projectile.GetComponent<Projectile>(), _muzzle.position, Quaternion.identity) as Projectile;
                _p.Init(damage, _muzzle.up);
                }
                nextSpawn = Time.time + interval;
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
