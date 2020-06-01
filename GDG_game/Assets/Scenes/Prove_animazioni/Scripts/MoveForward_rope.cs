using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/MoveForward_rope")]
    public class MoveForwanrd_rope : StateData
    {
        public CharacterControl control;
        public float swingForce;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            Vector3 perpendicularDirection;
            // Get normalized direction vector from player to the hook point
            var playerToHookDirection = (control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.position - control.transform.position).normalized;
            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("right");
                perpendicularDirection = new Vector3(0, -playerToHookDirection.z, playerToHookDirection.y);
                var leftPerpPos = control.transform.position - perpendicularDirection * -2f;
                Debug.DrawLine(control.transform.position, leftPerpPos, Color.green, 0f);
                var force = perpendicularDirection * swingForce;
                control.transform.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                perpendicularDirection = new Vector3(0, playerToHookDirection.z, -playerToHookDirection.y);
                var rightPerpPos = control.transform.position - perpendicularDirection * -2f;
                Debug.DrawLine(control.transform.position, rightPerpPos, Color.green, 0f);
                var force = perpendicularDirection * swingForce;
                control.transform.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);
            }

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}