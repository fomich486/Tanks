using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Movement))]
    public class InputController : MonoBehaviour
    {
        private Movement movement;

        private void Awake()
        {
            movement = GetComponent<Movement>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
                movement.CurrentDirection = Vector3.forward;
            else if (Input.GetKey(KeyCode.S))
                movement.CurrentDirection = Vector3.back;
            else if (Input.GetKey(KeyCode.D))
                movement.CurrentDirection = Vector3.right;
            else if (Input.GetKey(KeyCode.A))
                movement.CurrentDirection = Vector3.left;
            else
                movement.CurrentDirection = Vector3.zero;
        }
    }
}
