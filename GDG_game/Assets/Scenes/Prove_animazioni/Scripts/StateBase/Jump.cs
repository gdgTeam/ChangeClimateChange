using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float JumpForce;
        public AnimationCurve Gravity;
        //public AnimationCurve Pull;
        private BoxCollider box;
        private float bottom;
        private float zeta;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * JumpForce);
           // characterState.GetCharacterControl(animator).RIGID_BODY.constraints = RigidbodyConstraints.FreezeRotation;
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
            box = animator.GetComponentInParent<BoxCollider>();
            bottom = box.size.y;
            zeta = box.size.z;
            box.size = new Vector3(box.size.x, 0.5f, 0.3f);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           CharacterControl control= characterState.GetCharacterControl(animator);
            control.GravityMultiplier=Gravity.Evaluate(stateInfo.normalizedTime);
            //control.PullMultiplier= Pull.Evaluate(stateInfo.normalizedTime);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
            box.size = new Vector3(box.size.x, bottom, zeta);
        }
    }
}