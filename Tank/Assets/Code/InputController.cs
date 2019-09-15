using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks;

namespace Controlls
{
    [RequireComponent(typeof(PlayerTank))]
    public class InputController : MonoBehaviour
    {
        private PlayerTank playerTank;

        private void Awake()
        {
            playerTank = GetComponent<PlayerTank>();
        }

        private void Update()
        {
            ControllMovementInput();
            ControllShootInput();
            ChangeWeaponInput();
            LookAtMouse();
        }

        private void ControllMovementInput()
        {
            if (Input.GetKey(KeyCode.W))
                playerTank.CurrentDirection = Vector3.forward;
            else if (Input.GetKey(KeyCode.S))
                playerTank.CurrentDirection = Vector3.back;
            else if (Input.GetKey(KeyCode.D))
                playerTank.CurrentDirection = Vector3.right;
            else if (Input.GetKey(KeyCode.A))
                playerTank.CurrentDirection = Vector3.left;
            else
                playerTank.CurrentDirection = Vector3.zero;
        }

        private void ControllShootInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerTank.Shoot();
            }
        }

        private void ChangeWeaponInput()
        {

            //throw new NotImplementedException();
        }

        private void LookAtMouse()
        {
            Plane plane = new Plane(Vector3.up, transform.position);


            float distance;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 position = ray.GetPoint(distance);
                playerTank.CurrentWeapon.transform.LookAt(position);
            }
        }
    }
}
