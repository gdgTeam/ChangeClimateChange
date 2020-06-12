using System.Collections;
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
            animator.SetBool("LancioCorda", false);
            control = characterState.GetCharacterControl(animator);
            control.isSwinging = true;
            
            rope = control.transform.GetComponent<LineRenderer>();
            {
                rope.enabled = true;
                rope.SetPosition(0, control.spine.transform.position);
                Vector3 ancoraggio = new Vector3(control.transform.position.x, control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.transform.position.y, control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.transform.position.z);
                rope.SetPosition(1, ancoraggio);
            }

            control.liana.transform.position = control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.transform.position;
            if (control.transform.GetComponent<DistanceJoint3D>().enabled == false)
            {
                
                control.transform.GetComponent<DistanceJoint3D>().enabled = true;
                control.liana.GetComponent<MeshRenderer>().enabled = true;
                control.liana.GetComponent<Animator>().enabled = true;
                control.liana.GetComponent<Animator>().SetBool("Liana", true);

            }
           
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 1);
           
            

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
            control = characterState.GetCharacterControl(animator);
            control.transform.GetComponent<DistanceJoint3D>().enabled = false;
            rope.enabled = false;
           
            control.liana.GetComponent<MeshRenderer>().enabled = false;
            control.liana.GetComponent<Animator>().enabled = false;
            control.liana.GetComponent<Animator>().SetBool("Liana", false);
            control.isSwinging = false;
            control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody = null;
            animator.SetLayerWeight(0, 1);
            animator.SetLayerWeight(1, 0);
        }
    }
}
