using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Robot_CharacterDetection")]
    public class Robot_characterDetection : StateData
    {
        public bool playerDetected;
        private RobotControl control;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerDetected = false;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerDetected == false)
            {
                control = animator.GetComponentInParent<RobotControl>();
                playerDetected = checkFront(control);
                if (playerDetected)
                    animator.SetBool("CharacterDetected", true);
                else
                    animator.SetBool("CharacterDetected", false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }


        private bool checkFront(RobotControl control)
        {
            RaycastHit hit;
            Debug.DrawRay(control.EdgeCollider.transform.position, control.transform.forward, Color.yellow);
            if(Physics.Raycast(control.EdgeCollider.gameObject.transform.position, control.transform.forward, out hit, 100f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
