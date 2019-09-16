using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks {
    public class YellowEnemyTank : GreenEnemyTank
    {
        protected float randomMovementTime = 2f;
        protected float followMovementTime = 2f;
        protected float startFollowMovementTime;
        protected float changeRandomDirectionTime;
        protected int changeDirectionTimes = 3;

        protected override Vector3 GetFollowDirection()
        {
            if (Time.time < startFollowMovementTime)
            {
                if (Time.time > changeRandomDirectionTime)
                {
                    currentDirection = Utility.GetRandomDirectionForTankMovement(currentDirection);
                    changeRandomDirectionTime = Time.time + randomMovementTime / changeDirectionTimes;
                }
                return currentDirection;
            }
            else if (Time.time < startFollowMovementTime + followMovementTime - updateDelay)
            {
                return base.GetFollowDirection();
            }
            else
            {
                startFollowMovementTime = Time.time + randomMovementTime;
                changeRandomDirectionTime = Time.time;
                return base.GetFollowDirection();
            }
        }

        protected override void Start()
        {
            base.Start();
            reward = 10;
            armor = 8;
            updateDelay = GameController.Instance.PlayerComunicator.UpdateRate / 1.25f;

            startFollowMovementTime = Time.time + randomMovementTime;
            changeRandomDirectionTime = Time.time;

        }
    }
}
