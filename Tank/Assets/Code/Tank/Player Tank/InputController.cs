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
           // throw new NotImplementedException();
        }

        private void ChangeWeaponInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("Inputed to shoot");
                playerTank.Shoot();
            }
            //throw new NotImplementedException();
        }
    }
}
