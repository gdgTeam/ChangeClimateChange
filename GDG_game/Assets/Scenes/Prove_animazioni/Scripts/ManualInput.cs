using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl characterControl;

        private void Awake()
        {
            characterControl = this.gameObject.GetComponent<CharacterControl>();
        }

        void Update()
        {
            if (VirtualInputManager.Instance.MoveUp)
            {
                characterControl.MoveUp = true;
            }
            else
            {
                characterControl.MoveUp = false;
            }
            if (VirtualInputManager.Instance.MoveDown)
            {
                characterControl.MoveDown = true;
            }
            else
            {
                characterControl.MoveDown = false;
            }
            if (VirtualInputManager.Instance.MoveRight)
            {
                characterControl.MoveRight = true;
            }
            else
            {
                characterControl.MoveRight = false;
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                characterControl.MoveLeft = true;
            }
            else
            {
                characterControl.MoveLeft = false;
            }

            if (VirtualInputManager.Instance.Jump)
            {
                characterControl.Jump = true;
            }
            else
            {
                characterControl.Jump = false;
            }

            if (VirtualInputManager.Instance.Pushing)
            {
                characterControl.Pushing = true;
            }
            else
            {
                characterControl.Pushing = false;
            }

            if (VirtualInputManager.Instance.Picking)
            {
                characterControl.Picking = true;
            }
            else
            {
                characterControl.Picking = false;
            }

            if (VirtualInputManager.Instance.Shielding)
            {
                characterControl.Shielding = true;
            }
            else
            {
                characterControl.Shielding = false;
            }

            if (VirtualInputManager.Instance.PickingDown)
            {
                characterControl.PickingDown = true;
            }
            else
            {
                characterControl.PickingDown = false;
            }
            if (VirtualInputManager.Instance.Spiderman)
            {
                characterControl.Spiderman = true;
            }
            else
            {
               characterControl.Spiderman = false;

            }
            if (VirtualInputManager.Instance.LookRight)
            {
                characterControl.LookRight = true;
            }
            else
            {
                characterControl.LookRight = false;
            }

            if (VirtualInputManager.Instance.LookLeft)
            {
                characterControl.LookLeft = true;
            }
            else
            {
                characterControl.LookLeft = false;
            }
        }
    }
}
