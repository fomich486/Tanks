using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class GreenEnemyTank : EnemyTank
    { 
        private Vector3 lastMoveDirection;

        public override Vector3 CurrentDirection
        {
            get
            {
                return GetFollowDirection();
            }
        }

        protected virtual Vector3 GetFollowDirection()
        {
            currentWeapon.canShoot = false;
            Vector3 _playerPosition = GameController.Instance.PlayerComunicator.Position;
            Vector3 _directionToPlayer = _playerPosition - transform.position;

            Debug.DrawRay(transform.position, _directionToPlayer.normalized * 10, Color.red);
            Debug.DrawLine(transform.position, _playerPosition, Color.green);

            transform.rotation = Quaternion.LookRotation(_directionToPlayer);

            float _distance = Vector3.Distance(transform.position, _playerPosition);

            //TODO : add something like attack distance for yellow tank
            if (_distance < atackDistance)
            {
                    currentWeapon.canShoot = true;
                    currentDirection = Vector3.zero;
            }
            else
            {
                currentDirection = _directionToPlayer;
            }

            return currentDirection.normalized;
        }

        public override void Die()
        {
            base.Die();
        }

        protected override void InitValues()
        {
            reward = 5;
            maxArmor = 4;
            speed = GameController.Instance.PlayerComunicator.Speed / 1.4f;
            weaponType = FactorySpace.WeaponsTypes.Simple;
            atackDistance = GameController.Instance.ScreenDiagonal / 3;
        }
    }
}
