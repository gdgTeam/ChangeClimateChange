using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/StayingWithMetal")]
    public class StayingWithMetal : StateData
    {
        public GameObject metallo;
        public CharacterControl control;
        public float posX;
        public float posZ;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            metallo = GameObject.Find("BarraMetallo");
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetLayerWeight(3, 1);
            posX = control.gameObject.transform.position.x;
            posZ = control.gameObject.transform.position.z;
            metallo.transform.position = new Vector3(posX, metallo.transform.position.y, posZ);
        }
    }
}
