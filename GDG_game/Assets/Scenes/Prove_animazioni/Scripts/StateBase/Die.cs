using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Die")]
    public class Die : StateData
    {
        

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            control.Die = true;
            
            if (animator.GetBool("FallToDie"))
            {
                animator.SetBool("FallToDie", false);
            }
            if (animator.GetBool("Morte"))
            {
                animator.SetBool("Morte", false);
            }
        }
    }
}

