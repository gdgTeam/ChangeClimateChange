using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Robot_TurnOnPlace")]
    public class Robot_turnOnPlace : StateData
    {
        private RobotControl control;
        public float SpeedRotation;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = animator.GetComponentInParent<RobotControl>();
            if (control.transform.rotation.eulerAngles.y < 180 && control.MoveRight)
            {
                control.transform.Rotate(new Vector3(0, SpeedRotation, 0), Space.Self);
            }
            else
            {
                animator.SetBool("Walk", true);
            }
            if (control.transform.rotation.eulerAngles.y > 0 && control.MoveLeft)
            {
                control.transform.Rotate(new Vector3(0, -SpeedRotation, 0), Space.Self);
            }
            

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (control.MoveRight)
            {
              
                control.transform.rotation = Quaternion.Euler(0, 180f, 0);
                control.dir = +1;
                if(control.fatto==false)
                control.SetCollidersSpheresRight();
            }
            else
            {
                control.transform.rotation = Quaternion.Euler(0, 0, 0);
               control.dir = +1;
                if(control.fatto2==false)
                control.SetCollidersSpheresLeft();
            }

            // animator.SetBool("OnPlace", false);
            //animator.SetBool("Walk", true);
        }
    }
}

