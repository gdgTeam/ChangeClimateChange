using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Robot_Run")]
    public class Robot_run : StateData
    {
        private RobotControl control;
        public float Speed;
        public AnimationCurve SpeedGraph;
        public GameObject player;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            player = GameObject.FindGameObjectWithTag("Player");
           // animator.transform.position = new Vector3(animator.transform.position.x, 3.65f, animator.transform.position.z);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            //animator.transform.position = new Vector3(animator.transform.position.x, 3.65f, animator.transform.position.z);
            control = animator.GetComponentInParent<RobotControl>();
            /*if (control.MoveRight)
                control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            if (control.MoveLeft)
                control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
*/
            Vector3 targetDirection = control.transform.position - player.transform.position ;
            targetDirection.y = 0f;
            targetDirection.Normalize();
            control.transform.Translate(targetDirection * 6.5f * Time.deltaTime);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
