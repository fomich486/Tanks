using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class PlayerTank : Tank
    {
        private Vector3 currentDirection;
        public Vector3 CurrentDirection
        {
            get => currentDirection;
            set
            {
                if (value == Vector3.right || value == Vector3.left || value == Vector3.forward || value == Vector3.back || value == Vector3.zero || value == Vector3.zero)
                    currentDirection = value;
                else
                   return;
            }
        }

        public override int Armor {
            get => armor;
            set
            {
                if (armor <= 0)
                    Die();
            }
        }

        protected override void Move()
        {
            Vector3 _nextPosition = transform.position + currentDirection;
            if (!CheckBorders(_nextPosition))
            {
                transform.position = _nextPosition;
            }

            if (currentDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(currentDirection);
        }

        protected override void Shoot()
        {
            
        }

        protected override void Die()
        {
            throw new System.NotImplementedException();
        }
    }
}
