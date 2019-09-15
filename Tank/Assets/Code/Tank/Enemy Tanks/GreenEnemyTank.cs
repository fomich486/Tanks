using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class GreenEnemyTank : EnemyTank
    {
        protected override void Start()
        {
            base.Start();
            reward = 5;
            armor = 4;
            updateDelay /= 1.4f;
        }

        //public override void Shoot()
        //{
        //    throw new System.NotImplementedException();
        //}

        protected override void Die()
        {
            throw new System.NotImplementedException();
        }

        //protected override void Move()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
