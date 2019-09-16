using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class RedEnemyTank : GreenEnemyTank
    {
        Vector3 lastPlayerPosition;
        Vector3 playerShiftDirection;
        float lastDistance = 0;
        float basicIteraion = 0;
        bool isChasing;
        protected float iterationTime = .5f;
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
                    updateDelay = basicIteraion / chaseUpdateCoef;
                    base.GetFollowDirection();
                }
                else
                {
                    updateDelay = basicIteraion * runUpdateCoef;
                    if (Mathf.Abs(playerShiftDirection.x) >= Mathf.Abs(playerShiftDirection.z))
                    {
                        int dirCoef = -1 * (int)((Mathf.Abs(playerShiftDirection.x) / playerShiftDirection.x));
                        currentDirection = Vector3.right * dirCoef;
                        return currentDirection.normalized;
                    }
                    else 
                    {
                        int dirCoef = -1 * (int)((Mathf.Abs(playerShiftDirection.z) / playerShiftDirection.z));
                        currentDirection = Vector3.forward * dirCoef;
                        return currentDirection.normalized;
                    }
                }
            }
            else
            {
                isChasing = _currentDistance >= lastDistance;

                playerShiftDirection = lastPlayerPosition - _currentPlayerPosition;
                Debug.DrawLine(lastPlayerPosition, _currentPlayerPosition, Color.white,1.5f);

                nextChangeIterationTime = Time.time + iterationTime;
                lastPlayerPosition = _currentPlayerPosition;
                lastDistance = _currentDistance;
            }
            return currentDirection.normalized;
        }

        protected override void InitValues()
        {
            maxArmor = 10;
            reward = 15;
            basicIteraion = GameController.Instance.PlayerComunicator.UpdateRate;
            lastPlayerPosition = GameController.Instance.PlayerComunicator.Position;
        }
    }
}
