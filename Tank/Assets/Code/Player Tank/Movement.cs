using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private float nextUpdateTime = 0f;
        [SerializeField]
        private float updateDelay = 0.2f;

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

        private void FixedUpdate()
        {
            if (Time.time > nextUpdateTime)
            {
                Move();
                nextUpdateTime = Time.time + updateDelay;
            }
        }

        public void Move()
        {
            transform.position += currentDirection;
        }
    }
}
