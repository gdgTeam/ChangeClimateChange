using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Fall")]
    public class Fall : StateData
    {

        public float timeLeft =1.7f; 
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            timeLeft = 1.7f;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Debug.Log("altezza");
                animator.SetBool("FallToDie", true);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            timeLeft = 1.7f;
        }
    }
}
