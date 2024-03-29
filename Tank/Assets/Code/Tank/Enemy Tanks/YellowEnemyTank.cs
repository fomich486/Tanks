﻿using System.Collections;
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
                currentWeapon.canShoot = false;
                if (Time.time > changeRandomDirectionTime)
                {
                    currentDirection = Utility.GetRandomDirectionForTankMovement();
                    changeRandomDirectionTime = Time.time + randomMovementTime / changeDirectionTimes;
                }
                return currentDirection;
            }
            else if (Time.time < startFollowMovementTime + followMovementTime)
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

        protected override void InitValues()
        {
            reward = 10;
            maxArmor = 8;
            if(GameController.Instance.PlayerComunicator!=null)
                speed = GameController.Instance.PlayerComunicator.Speed / 1.25f;

            startFollowMovementTime = Time.time + randomMovementTime;
            changeRandomDirectionTime = Time.time;
            weaponType = FactorySpace.WeaponsTypes.Double;

            atackDistance = Mathf.Infinity;
            MaterialName = "Yellow";
        }
    }
}
