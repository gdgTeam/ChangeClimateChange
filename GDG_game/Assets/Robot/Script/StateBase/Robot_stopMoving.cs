using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Robot_StopMoving")]
    public class Robot_stopMoving : StateData
    {
        private RobotControl control;
        public float Speed;
        public AnimationCurve SpeedGraph;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = animator.GetComponentInParent<RobotControl>();
            control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
