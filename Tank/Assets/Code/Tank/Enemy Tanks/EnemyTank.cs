using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public abstract class EnemyTank : Tank
    {
        protected float atackDistance;

        protected int reward;
        protected virtual int Reward { get => reward; }

        private EnemyHealthbar healthBar;
        private Vector3 healthBarOffset;
        private Vector3 healthbarPosition { get => transform.position + healthBarOffset; }

        protected override void Start()
        {
            base.Start();

            healthBarOffset = Vector3.back * (transform.localScale.z / 2 + 0.1f);
            healthBar = Instantiate(Resources.Load("CanvasHealthbar") as GameObject, healthbarPosition, Quaternion.LookRotation(Vector3.up)).GetComponent<EnemyHealthbar>();
        }

        protected void HealthBarUpdate()
        {
            healthBar.transform.position = healthbarPosition;
            healthBar.ChangeHealth((float)armor / (float)maxArmor);
        }

        protected override void Update()
        {
            base.Update();
           // Shoot();
            HealthBarUpdate();
        }

        protected override void SpawnTower()
        {
            base.SpawnTower();
            currentWeapon.transform.parent = transform;
        }

        public override void Die()
        {
            Destroy(healthBar.gameObject);
            base.Die();
        }
    }
}
