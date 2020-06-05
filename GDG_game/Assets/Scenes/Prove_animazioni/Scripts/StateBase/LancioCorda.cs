using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/LancioCorda")]
    public class LancioCorda : StateData
    {
        public CharacterControl control;
        private LineRenderer rope;
        //public GameObject pianta;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            control = characterState.GetCharacterControl(animator);
           
            control.isSwinging = true;
            rope = control.transform.GetComponent<LineRenderer>();
            control.liana.transform.position = control.transform.position;
            control.liana.GetComponent<MeshRenderer>().enabled = true;
            control.liana.GetComponent<Animator>().enabled = true;

           

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
           
            rope.enabled = true;
            control.transform.GetComponent<DistanceJoint3D>().enabled = true;
            rope.SetPosition(0, control.spine.transform.position);
            rope.SetPosition(1, control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.transform.position);
            
        }
    }
}
