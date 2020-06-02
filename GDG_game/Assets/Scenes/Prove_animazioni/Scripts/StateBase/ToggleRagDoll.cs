using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/ToggleRagDoll")]
    public class ToggleRagDoll : StateData
    {
        public bool OnStart;
        public bool OnEnd;
        public bool on;


        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnStart)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                ToggleragDoll(control);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (OnEnd)
            {
              
                ToggleragDoll(control);
            }
            control.Ragdoll = false;

        }

        private void ToggleragDoll(CharacterControl control)
        {

            control.Ragdoll = on;
        }


    }
}