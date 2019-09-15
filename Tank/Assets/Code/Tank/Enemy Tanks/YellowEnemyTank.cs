using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks {
    public class YellowEnemyTank : GreenEnemyTank
    {
        float randomMovementTime = 2f;
        float followMovementTime = 2f;
        float startFollowMovementTime;
        float changeRandomDirectionTime;
        int changeDirectionTimes = 3;

        public override Vector3 CurrentDirection
        {
            get
            {
                if (Time.time < startFollowMovementTime)
                {
                    if (Time.time > changeRandomDirectionTime)
                    {
                        currentDirection = Utility.GetRandomDirectionForTankMovement(currentDirection);
                        print("Direction changed and current is " + currentDirection);
                        changeRandomDirectionTime = Time.time + randomMovementTime/ changeDirectionTimes;
                    }
                    return currentDirection;
                }
                else if (Time.time < startFollowMovementTime + followMovementTime - updateDelay)
                {
                    return GetSimpleTankFollowDirection();
                }
                else
                {
                    startFollowMovementTime = Time.time + randomMovementTime;
                    changeRandomDirectionTime = Time.time;
                    return GetSimpleTankFollowDirection();
                }
            }
        }

        protected override void Start()
        {
            base.Start();
            reward = 10;
            armor = 8;
            updateDelay /= 1.25f;

            startFollowMovementTime = Time.time + randomMovementTime;
            changeRandomDirectionTime = Time.time;
        }
    }
}
