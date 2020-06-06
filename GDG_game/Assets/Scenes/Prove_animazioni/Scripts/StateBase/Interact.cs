using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Interact")]
    public class Interact : StateData
    {

        public AnimationCurve SpeedGraph;
        public float Speed;
        public float PushDistance;
        private bool tree = false;
        private GameObject pushableTree;
        private Vector3 rotation;



        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //PushDistance = 0.5f;
            CharacterControl control = characterState.GetCharacterControl(animator);
            rotation = control.transform.rotation.eulerAngles;
            //tree = CheckObjectFront(control, animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if ((control.MoveRight && rotation==control.right) || (control.MoveLeft && rotation==control.left))
            {
                animator.SetBool(TransitionParameter.Push.ToString(), true);
                animator.SetBool(TransitionParameter.Pull.ToString(), false);
            }
            else if((control.MoveRight && rotation==control.left) || (control.MoveLeft && rotation==control.right))
            {
                animator.SetBool(TransitionParameter.Pull.ToString(), true);
                animator.SetBool(TransitionParameter.Push.ToString(), false);
            }
            else if(!control.MoveRight && !control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Push.ToString(), false);
                animator.SetBool(TransitionParameter.Pull.ToString(), false);
            }

            if (!control.Interact)
            {
                animator.SetBool(TransitionParameter.Interact.ToString(), false);
                return;
            }

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckObjectFront(CharacterControl control, Animator animator)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, PushDistance) && hit.collider.gameObject.tag == "PushableTree")
                {

                    pushableTree = hit.collider.gameObject;
                    Debug.Log(hit.collider.gameObject);
                    return true;
                }
            }

            return false;
        }

    }
}
