using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PushStop")]
    public class PushStop : StateData
    {
        GameObject childToRemove;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            childToRemove = findChildrenWithTag(animator);
            childToRemove.transform.parent = null;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public GameObject findChildrenWithTag(Animator animator)
        {
            foreach (Transform t in animator.gameObject.transform)
            {
                if (t.gameObject.tag == "Pushable")
                {
                    return t.gameObject;
                }
                else if (t.gameObject.tag == "PushableTree")
                {
                    return t.gameObject;
                }
            }
            return null;
        }
    }
}