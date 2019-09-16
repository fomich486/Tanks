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
            if (transform.position.x > GameController.Instance.MapSize.x / 2 || transform.position.x < -GameController.Instance.MapSize.x / 2 ||
                transform.position.z > GameController.Instance.MapSize.y / 2 || transform.position.z < -GameController.Instance.MapSize.y / 2)
            {
                Die();
            }
            transform.Translate(direction * speed * Time.deltaTime);
        }

        public void OnCollisionEnter(Collision collision)
        {
            IDamageable damageble = collision.gameObject.GetComponent<IDamageable>();
            print(collision.collider.name);
            if (damageble != null)
            {
                print("Projectile is aimed");
                damageble.ReceiveDamage(damage);
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}
