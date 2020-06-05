﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class KeyboardInput : MonoBehaviour
    {
        private bool protectShield = true;
        private bool protectPlant = false;
        private CharacterControl control;

        private void Start()
        {
            control = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();

        }
        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.MoveRight = true;
                VirtualInputManager.Instance.Move = true;
                VirtualInputManager.Instance.LookRight = true;
                VirtualInputManager.Instance.LookLeft = false;
            }
            else
            {
                VirtualInputManager.Instance.MoveRight = false;
                VirtualInputManager.Instance.Move = false;
                //VirtualInputManager.Instance.LookRight = false;
            }
            if (Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.MoveUp = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveUp = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                VirtualInputManager.Instance.MoveDown = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveDown = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.MoveLeft = true;
                VirtualInputManager.Instance.Move = true;
                VirtualInputManager.Instance.LookLeft = true;
                VirtualInputManager.Instance.LookRight = false;
            }
            else
            {
                VirtualInputManager.Instance.MoveLeft = false;
                VirtualInputManager.Instance.Move = false;
                //VirtualInputManager.Instance.LookLeft = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                VirtualInputManager.Instance.Jump = true;
            }
            else
            {
                VirtualInputManager.Instance.Jump = false;
            }

            if (Input.GetKey(KeyCode.E))
            {
                VirtualInputManager.Instance.Pushing = true;
                VirtualInputManager.Instance.Interact = true;
            }
            else
            {
                VirtualInputManager.Instance.Pushing = false;
                VirtualInputManager.Instance.Interact = false;
            }

            if (Input.GetKey(KeyCode.Q) && !protectPlant)
            {
                protectPlant = true;
                VirtualInputManager.Instance.Picking = true;
            }
            else
            {
                VirtualInputManager.Instance.Picking = false;
            }

            if(Input.GetKey(KeyCode.Q) && !VirtualInputManager.Instance.Picking && protectPlant)
            {
                protectPlant = false;
                VirtualInputManager.Instance.PickingDown = true;
            }
            else
            {
                VirtualInputManager.Instance.PickingDown = false;
            }

            if (Input.GetMouseButtonDown(2) && protectShield)
            {
                protectShield = false;
                VirtualInputManager.Instance.Shielding = true;
                StartCoroutine("Shield");
            }
            if (Input.GetMouseButtonDown(1) && control.Pointed==true  )
            {
              
                VirtualInputManager.Instance.Spiderman = true;
                
            }
            if (Input.GetMouseButtonUp(1))
            {

                VirtualInputManager.Instance.Spiderman = false;

            }

        }

        IEnumerator Shield()
        {
            yield return new WaitForSeconds(6.5f);
            VirtualInputManager.Instance.Shielding = false;
            yield return new WaitForSeconds(2f);
            protectShield = true;
        }
    }
}

