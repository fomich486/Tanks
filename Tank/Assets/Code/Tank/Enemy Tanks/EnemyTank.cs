using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public abstract class EnemyTank : Tank
    {
        protected int reward;
        protected virtual int Reward { get => reward; }

        protected override void Update()
        {
            base.Update();
            Shoot();
        }

        protected override void SpawnTower()
        {
            base.SpawnTower();
            currentWeapon.transform.parent = transform;
        }
    }
}
