using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class RedEnemyTank : GreenEnemyTank
    {
        Vector3 lastPlayerPosition;
        float lastDistance = 0;
        float basicIteraion = 0;
        bool isChasing;
        protected float iterationTime = .75f;
        protected float nextChangeIterationTime;
        protected float chaseUpdateCoef = 1.2f;
        protected float runUpdateCoef = 1.2f;

        public override void Die()
        {
            base.Die();
        }

        protected override Vector3 GetFollowDirection()
        {
            Vector3 _currentPlayerPosition = GameController.Instance.PlayerComunicator.Position;
            float _currentDistance = Vector3.Distance(_currentPlayerPosition, lastPlayerPosition);
            if (Time.time < nextChangeIterationTime)
            {
                if (isChasing)
                {
                    speed = basicIteraion / chaseUpdateCoef;
                    currentDirection = base.GetFollowDirection();
                }
                else
                {
                    currentWeapon.canShoot = false;
                    speed = basicIteraion * runUpdateCoef;
                }

                lastPlayerPosition = _currentPlayerPosition;
                lastDistance = _currentDistance;
            }
            else
            {
                isChasing = _currentDistance >= lastDistance;
                if (!isChasing)
                {
                    currentDirection = transform.position - _currentPlayerPosition;
                }
                nextChangeIterationTime = Time.time + iterationTime;
            }
            return currentDirection.normalized;
        }

        protected override void InitValues()
        {
            maxArmor = 10;
            reward = 15;
            basicIteraion = GameController.Instance.PlayerComunicator.Speed;
            lastPlayerPosition = GameController.Instance.PlayerComunicator.Position;
            weaponType = FactorySpace.WeaponsTypes.Double;
            atackDistance = GameController.Instance.ScreenDiagonal / 1.5f;
            MaterialName = "Red";
        }
    }
}
