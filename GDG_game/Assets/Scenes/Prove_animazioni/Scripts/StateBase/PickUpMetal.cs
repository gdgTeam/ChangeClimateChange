using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PickUpMetal")]
    public class PickUpMetal : StateData
    {
        public GameObject barraMetallo;
        CharacterControl control;
        private Rigidbody rbPianta;
        private Rigidbody rbPersonaggio;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            barraMetallo = GameObject.Find("BarraMetallo");
            barraMetallo.transform.parent = null;
            rbPersonaggio = control.transform.GetComponent<Rigidbody>();
            rbPianta = barraMetallo.transform.GetComponent<Rigidbody>();
            rbPersonaggio.isKinematic = true;
            rbPianta.isKinematic = true;
            barraMetallo.transform.SetParent(GameObject.Find("mixamorig:RightHand").transform);
            control.pickedMetal = true;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
