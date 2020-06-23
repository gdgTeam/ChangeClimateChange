using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class KeyboardInput : MonoBehaviour
    {
        private bool protectShield = true;
        private CharacterControl control;
        private Animator animator;
        private bool PickUp;
        private bool PickDown;

        private void Start()
        {
            control = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
            animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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
                control.saltando = true;
            }
            else
            {
                VirtualInputManager.Instance.Jump = false;
                control.saltando = false;
            }

            if (Input.GetKey(KeyCode.E))
            {
                control.spingendo = true;
                //VirtualInputManager.Instance.Pushing = true;
                VirtualInputManager.Instance.Interact = true;
            }
            else
            {
                control.spingendo = false;
                //VirtualInputManager.Instance.Pushing = false;
                VirtualInputManager.Instance.Interact = false;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                Debug.Log("Qui");
                if (control.PickPlant == true || control.PickMetal == true)
                {
                    control.prendendo = true;
                    VirtualInputManager.Instance.Picking = true;
                }
            }
            else
            {
                control.prendendo = false;
                VirtualInputManager.Instance.Picking = false;
            }

            if (control.controllaPosaPianta)
            {
                if (Input.GetKey(KeyCode.Q) && !VirtualInputManager.Instance.Picking)
                {
                    if (control.protectPlant || control.pickedMetal)
                    {
                        control.posando = true;
                        VirtualInputManager.Instance.PickingDown = true;
                    }
                }
                else
                {
                    control.posando = false;
                    VirtualInputManager.Instance.PickingDown = false;
                }
            }
            else
            {
                control.posando = false;
                VirtualInputManager.Instance.PickingDown = false;
            }
            if (control.controllaCorazza)
            {
                if (Input.GetMouseButtonDown(2) && protectShield && control.protectPlant)
                {
                    control.corazzando = true;
                    protectShield = false;
                    VirtualInputManager.Instance.Shielding = true;
                    VirtualInputManager.Instance.ShieldLast = true;
                    StartCoroutine("Shield");
                }
                else
                {
                    control.corazzando = false;
                }
            }
            else
            {
                control.corazzando = false;
            }
            if (control.controllaLiana)
            {
                if (Input.GetMouseButtonDown(1) && control.Pointed == true && control.protectPlant)
                {
                    control.lianando = true;
                    VirtualInputManager.Instance.Spiderman = true;

                }
                if (Input.GetMouseButtonUp(1) && control.protectPlant)
                {
                    control.lianando = false;
                    VirtualInputManager.Instance.Spiderman = false;

                }
            }
            else
            {
                control.lianando = false;
                VirtualInputManager.Instance.Spiderman = false;
            }

            if (control.controllaSparo)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && control.sparando == false)
                {
                    control.sparando = true;
                    VirtualInputManager.Instance.Fire = true;
                }
                else if(Input.GetKeyDown(KeyCode.LeftShift) && control.sparando == true)
                {
                    control.sparando = false;
                    VirtualInputManager.Instance.Fire = false;
                }
            }
            else
            {
                control.sparando = false;
                VirtualInputManager.Instance.Fire = false;
            }

         }
  

            IEnumerator Shield()
            {
                yield return new WaitForSeconds(5.5f);
                VirtualInputManager.Instance.ShieldLast = false;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = true;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = false;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = true;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = false;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = true;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = false;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = true;
                yield return new WaitForSeconds(0.25f);
                VirtualInputManager.Instance.ShieldLast = false;
                VirtualInputManager.Instance.Shielding = false;
                yield return new WaitForSeconds(2f);
                protectShield = true;
            }
        }
    }


