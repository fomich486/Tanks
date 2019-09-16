using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class GreenEnemyTank : EnemyTank
    { 
        private Vector3 lastMoveDirection;
        protected float atackDistance;

        public override Vector3 CurrentDirection
        {
            get
            {
                return GetFollowDirection();
            }
        }

        protected virtual Vector3 GetFollowDirection()
        {
            canShoot = false;
            Vector3 _playerPosition = GameController.Instance.PlayerComunicator.Position;
            Vector3 _directionToPlayer = _playerPosition - transform.position;

            Debug.DrawRay(transform.position, _directionToPlayer.normalized * 10, Color.red);
            Debug.DrawLine(transform.position, _playerPosition, Color.green);

            float _distance = Vector3.Distance(transform.position, _playerPosition);

            //TODO : add something like attack distance for yellow tank
            if (_distance < atackDistance)
            {
                if (_directionToPlayer.x == 0 || _directionToPlayer.z == 0)
                {
                    canShoot = true;
                    currentDirection = Vector3.zero;
                    transform.rotation = Quaternion.LookRotation(_directionToPlayer);
                }
                else
                {
                    currentDirection = lastMoveDirection;
                }
            }
            else
            {
                if (Mathf.Abs(_directionToPlayer.x) >= Mathf.Abs(_directionToPlayer.z))
                {
                    currentDirection = (int)(Mathf.Abs(_directionToPlayer.x) / _directionToPlayer.x) * Vector3.right;
                }
                else
                {
                    currentDirection = (int)(Mathf.Abs(_directionToPlayer.z) / _directionToPlayer.z) * Vector3.forward;
                }
                lastMoveDirection = currentDirection.normalized;
            }

            return currentDirection.normalized;
        }

        protected override void Start()
        {
            base.Start();
            reward = 5;
            armor = 4;
            updateDelay = GameController.Instance.PlayerComunicator.UpdateRate/ 1.4f;
            atackDistance = GameController.Instance.ScreenDiagonal / 3;
        }

        public override void Die()
        {
            base.Die();
        }

    }
}
