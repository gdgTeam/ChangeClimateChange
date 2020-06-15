using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PickDownMetal_1")]
    public class PickDownMetal_1 : StateData
    {

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetLayerWeight(3, 0);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}