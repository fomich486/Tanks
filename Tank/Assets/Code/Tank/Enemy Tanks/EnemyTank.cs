using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public abstract class EnemyTank : Tank
    {
        protected int reward;
        protected virtual int Reward { get => reward; }

        public override Vector3 CurrentDirection
        {
            get
            {
               Vector3 _playerPosition = GameController.Instance.SpawnedPlayerTank.position;
               Vector3 _directionToPlayer =  _playerPosition - transform.position;
                Debug.DrawRay(transform.position, _directionToPlayer.normalized * 10,Color.red);
                Debug.DrawLine(transform.position, _playerPosition,Color.green);
                if (Mathf.Abs(_directionToPlayer.x) >= Mathf.Abs(_directionToPlayer.z))
                {
                    currentDirection = (int)(Mathf.Abs(_directionToPlayer.x) / _directionToPlayer.x) * Vector3.right;
                }
                else
                {
                    currentDirection = (int)(Mathf.Abs(_directionToPlayer.z) / _directionToPlayer.z) * Vector3.forward;
                }
               return currentDirection.normalized;
            }
        }

        protected override void Update()
        {
            base.Update();
            Shoot();
        }

        public override void Shoot()
        {
            //base.Shoot();
        }
    }
}
