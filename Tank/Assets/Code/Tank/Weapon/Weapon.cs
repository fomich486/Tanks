using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        private Tank tankToFollow;
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
            LookAtMouse();
        }

        private void LookAtMouse()
        {
            Plane plane = new Plane(Vector3.up, transform.position);


            float distance;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 position = ray.GetPoint(distance);
                transform.LookAt(position);
            }
        }

        private void FollowTank()
        {
            transform.position = tankToFollow.MuzzlePosition;
        }
    }
}
