﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Swinging")]
    public class Swinging : StateData
    {
        public CharacterControl control;
        private LineRenderer rope;
      

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 1);
            control = characterState.GetCharacterControl(animator);
            control.transform.GetComponent<DistanceJoint3D>().enabled = true;
            control.isSwinging = true;
            rope = control.transform.GetComponent<LineRenderer>();
            rope.enabled = true;
            rope.SetPosition(0, control.spine.transform.position);
            rope.SetPosition(1, control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.transform.position);

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            rope.SetPosition(0, control.spine.transform.position);

            if (!control.Spiderman)
            {
                animator.SetBool(TransitionParameter.Spiderman.ToString(), false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control.transform.GetComponent<DistanceJoint3D>().enabled = false;
            rope.enabled = false;
            control.isSwinging = false;
            control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody = null;
            animator.SetLayerWeight(0, 1);
            animator.SetLayerWeight(1, 0);
        }
    }
}
