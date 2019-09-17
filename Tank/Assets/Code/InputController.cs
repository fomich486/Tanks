using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks;

namespace Controlls
{
    public class InputController : MonoBehaviour
    {
        private PlayerTank playerTank;

        private void Start()
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
            float _x = Input.GetAxis("Horizontal");
            float _z = Input.GetAxis("Vertical");
            Vector3 _newDirection = new Vector3(_x, 0f, _z);
            playerTank.CurrentDirection = _newDirection.normalized;
        }

        private void ControllShootInput()
        {
            if (Input.GetMouseButton(0))
            {
                playerTank.Shoot();
            }
        }

        private void ChangeWeaponInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerTank.NextWeapon();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                playerTank.PrevWeapon();
            }
        }

        private void LookAtMouse()
        {
            Plane plane = new Plane(Vector3.up, transform.position);


            float distance;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 position = ray.GetPoint(distance);
                playerTank.CurrentWeapon.transform.LookAt(new Vector3(position.x, playerTank.CurrentWeapon.transform.position.y,position.z));
            }
        }
    }
}
