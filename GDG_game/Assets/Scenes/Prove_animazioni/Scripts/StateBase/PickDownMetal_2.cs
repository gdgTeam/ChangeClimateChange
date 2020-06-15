using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PickDownMetal_2")]
    public class PickDownMetal_2 : StateData
    {
        public GameObject barraMetallo;
        CharacterControl control;
        private Rigidbody rbPianta;
        private Rigidbody rbPersonaggio;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            control.sparaOk = false;
            barraMetallo = GameObject.Find("BarraMetallo");
            rbPersonaggio = control.transform.GetComponent<Rigidbody>();
            rbPianta = barraMetallo.transform.GetComponent<Rigidbody>();
            rbPersonaggio.isKinematic = true;
            rbPianta.isKinematic = true;
            MeshRenderer piantinaManoMesh;
            BoxCollider piantinaManoCollider;
            piantinaManoMesh = barraMetallo.transform.GetComponent<MeshRenderer>();
            piantinaManoMesh.enabled = true;
            barraMetallo.transform.GetChild(0).transform.GetComponent<MeshRenderer>().enabled = true;
            piantinaManoCollider = barraMetallo.transform.GetComponent<BoxCollider>();
            piantinaManoCollider.enabled = false;
            control.pickedMetal = false;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            barraMetallo.transform.parent = null;
            BoxCollider piantinaManoCollider;
            piantinaManoCollider = barraMetallo.transform.GetComponent<BoxCollider>();
            piantinaManoCollider.enabled = true;
            barraMetallo.transform.position = new Vector3(control.transform.position.x, barraMetallo.transform.position.y, barraMetallo.transform.position.z);
            rbPersonaggio.isKinematic = false;
            rbPianta.isKinematic = false;
        }
    }
}