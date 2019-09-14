using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private Vector3 currentDirection;

        public Vector3 CurrentDirection { get => currentDirection; set => currentDirection = value; }

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
           // transform.position
        }
    }
}
