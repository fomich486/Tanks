using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Weapons
{
    public class Projectile : MonoBehaviour
    {
        protected int damage;
        protected Vector3 direction;
        protected float speed = 10;

        public void Init(int _damage, Vector3 _direction)
        {
            damage = _damage;
            direction = _direction.normalized;
        }

        protected virtual void Update()
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

        public void OnCollisionEnter(Collision collision)
        {
            
        }
    }
}
