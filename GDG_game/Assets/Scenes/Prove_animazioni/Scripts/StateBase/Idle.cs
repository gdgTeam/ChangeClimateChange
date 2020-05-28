using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Idle")]
    public class Idle : StateData
    {

        public float BlockDistance;
        public float PickDistance;
        public bool plant = false;
        public GameObject hand;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false); //per evitare di saltare due volte se premo spazio mentre sono nello stato di landing
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (control.MoveRight && control.LookRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
                //devo controllare dove sta guardando il personaggio
            }

            if (control.MoveLeft && control.LookLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if(control.MoveLeft && control.LookRight)
            {
                animator.SetBool(TransitionParameter.MoveBackward.ToString(), true);
            }

            if (control.MoveRight && control.LookLeft)
            {
                animator.SetBool(TransitionParameter.MoveBackward.ToString(), true);
            }

            if (control.Pushing && CheckFrontPush(control, animator))
            {
                animator.SetBool(TransitionParameter.Push.ToString(), true);
            }

            if (control.Picking && CheckFrontPick(control, animator) && !control.plant)
            {
                animator.SetBool(TransitionParameter.PickUp.ToString(), true);
            }
            else
            {
                animator.SetBool(TransitionParameter.PickUp.ToString(), false);
            }

            if (control.PickingDown && control.plant)
            {
                animator.SetBool(TransitionParameter.PickDown.ToString(), true);
            }
            else
            {
                animator.SetBool(TransitionParameter.PickDown.ToString(), false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFrontPush(CharacterControl control, Animator animator)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance) && (hit.collider.gameObject.tag == "Pushable" || hit.collider.gameObject.tag == "PushableTree"))
                {
                    hit.collider.gameObject.transform.SetParent(animator.gameObject.transform);
                    return true;
                }
            }

            return false;
        }

        bool CheckFrontPick(CharacterControl control, Animator animator)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, PickDistance) && hit.collider.gameObject.tag == "Pickable")
                {
                    if(hit.collider.gameObject == GameObject.Find("pianta"))
                    {
                        control.PickPlant = true;
                    }
                    else
                    {
                        control.PickPlant = false;
                    }
                    //hit.collider.gameObject.transform.SetParent(GameObject.Find("RightHand").transform);
                    return true;
                }
            }

            return false;
        }
    }
}