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
        Rigidbody rb;

        public void Init(int _damage, Vector3 _direction)
        {
            damage = _damage;
            direction = _direction.normalized;
            rb = GetComponent<Rigidbody>();
            rb.velocity = direction * speed;
        }

        protected virtual void Update()
        {
            if (transform.position.x > GameController.Instance.MapSize.x / 2 || transform.position.x < -GameController.Instance.MapSize.x / 2 ||
                transform.position.z > GameController.Instance.MapSize.y / 2 || transform.position.z < -GameController.Instance.MapSize.y / 2)
            {
                Die();
            }
            
        }

        //public void OnCollisionEnter(Collision collision)
        //{

        //}

        private void OnTriggerEnter(Collider collision)
        {
            IDamageable damageble = collision.gameObject.GetComponent<IDamageable>();
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (damageble != null)
            {
                damageble.ReceiveDamage(damage);
                Die();
            }
            if (projectile != null)
            {
                Destroy(collision.gameObject);
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}
