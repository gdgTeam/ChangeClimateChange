using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/TeleportOnLedge")]
    public class TeleportOnLedge : StateData
    {
       
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           // CharacterControl control = characterState.GetCharacterControl(animator);
           


        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            CharacterControl control = characterState.GetCharacterControl(animator);

            Vector3 endPosition = control.ledgeChecker.GrabbedLedge.transform.position + control.ledgeChecker.GrabbedLedge.EndPosition;
            //control.gameObject.transform.localScale = Vector3.one;
            control.transform.position = endPosition;
            control.SkinnedMeshAnimator.transform.position = endPosition;

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            control.ledgeChecker.RemoveLedge();
            control.SkinnedMeshAnimator.transform.parent = control.transform;
            control.gameObject.transform.localScale = control.scale;
        }


    }
}