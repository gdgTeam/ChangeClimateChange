using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/OffSetOnLedge")]
    public class OffsetOnLedge : StateData
    {
        //public Vector3 offsetTestaPiedi;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            GameObject anim = control.SkinnedMeshAnimator.gameObject;
           
            anim.transform.parent = control.ledgeChecker.GrabbedLedge.transform;
            anim.transform.localPosition = control.ledgeChecker.GrabbedLedge.Offset;
       }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            CharacterControl control = characterState.GetCharacterControl(animator);
            control.RIGID_BODY.velocity = Vector3.zero;
            GameObject anim = control.SkinnedMeshAnimator.gameObject;
            anim.transform.parent = null;
            control.gameObject.transform.localScale = control.scale;
        }


    }
}
