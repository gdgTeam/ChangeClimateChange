using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/MoveForward_rope")]
    public class MFW_rope : StateData
    {
        public CharacterControl control;
        public float swingForce;
        Vector3 perpendicularDirection;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);

            // Get normalized direction vector from player to the hook point
            var playerToHookDirection = (control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.position - control.transform.position).normalized;
            if (Input.GetKey(KeyCode.D))
            {

                perpendicularDirection = new Vector3(0, -playerToHookDirection.z, playerToHookDirection.y);
                var leftPerpPos = control.transform.position - perpendicularDirection * -2f;
                Debug.DrawLine(control.transform.position, leftPerpPos, Color.green, 0f);
                if (control.girato == false)
                {
                    animator.SetBool(TransitionParameter.front.ToString(), true);
                    animator.SetBool(TransitionParameter.back.ToString(), false);
                }
                else if (control.girato == true)
                {
                    animator.SetBool(TransitionParameter.front.ToString(), false);
                    animator.SetBool(TransitionParameter.back.ToString(), true);
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                perpendicularDirection = new Vector3(0, playerToHookDirection.z, -playerToHookDirection.y);
                var rightPerpPos = control.transform.position - perpendicularDirection * -2f;
                Debug.DrawLine(control.transform.position, rightPerpPos, Color.green, 0f);
                if (control.girato == false)
                {
                    animator.SetBool(TransitionParameter.front.ToString(), false);
                    animator.SetBool(TransitionParameter.back.ToString(), true);
                }
                else if (control.girato == true)
                {
                    animator.SetBool(TransitionParameter.front.ToString(), true);
                    animator.SetBool(TransitionParameter.back.ToString(), false);
                }


            }
            var force = perpendicularDirection * swingForce;
            control.transform.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
