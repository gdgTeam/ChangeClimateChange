using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PickDown")]
    public class PickDown : StateData
    {
        //public GameObject piantinaSpalla;
        public GameObject piantinaMano;
        private Rigidbody rbPianta;
        private Rigidbody rbPersonaggio;
        private CharacterControl control;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            control.sparaOk = false;
            piantinaMano = GameObject.Find("zaino+pianta");
            rbPersonaggio = control.transform.GetComponent<Rigidbody>();
            rbPianta = piantinaMano.transform.GetComponent<Rigidbody>();
            rbPersonaggio.isKinematic = true;
            rbPianta.isKinematic = true;
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = false;*/
            MeshRenderer piantinaManoMesh;
            BoxCollider piantinaManoCollider;
            control.gameObject.transform.GetChild(3).transform.GetComponent<SkinnedMeshRenderer>().enabled = false;
            control.gameObject.transform.GetChild(2).transform.GetComponent<SkinnedMeshRenderer>().enabled = false;
            piantinaManoMesh = piantinaMano.transform.GetComponent<MeshRenderer>();
            piantinaManoMesh.enabled = true;
            piantinaMano.transform.GetChild(0).transform.GetComponent<MeshRenderer>().enabled = true;
            piantinaManoCollider = piantinaMano.transform.GetComponent<BoxCollider>();
            piantinaManoCollider.enabled = false;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            piantinaMano.transform.parent = null;
            control.plant = false;
            BoxCollider piantinaManoCollider;
            piantinaManoCollider = piantinaMano.transform.GetComponent<BoxCollider>();
            piantinaManoCollider.enabled = true;
            piantinaMano.transform.position = new Vector3(control.transform.position.x, piantinaMano.transform.position.y, piantinaMano.transform.position.z);
            rbPersonaggio.isKinematic = false;
            rbPianta.isKinematic = false;
            control.checkPick = true;
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = true;*/
        }
    }
}