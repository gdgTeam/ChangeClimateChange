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
            piantinaMano = GameObject.Find("piantina_prova");
            rbPersonaggio = control.transform.GetComponent<Rigidbody>();
            rbPianta = piantinaMano.transform.GetComponent<Rigidbody>();
            rbPersonaggio.isKinematic = true;
            rbPianta.isKinematic = true;
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = false;*/
            MeshRenderer piantinaManoMesh;
            MeshCollider piantinaManoCollider;
            piantinaManoMesh = piantinaMano.transform.GetComponent<MeshRenderer>();
            piantinaManoMesh.enabled = true;
            piantinaManoCollider = piantinaMano.transform.GetComponent<MeshCollider>();
            piantinaManoCollider.enabled = false;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            piantinaMano.transform.parent = null;
            control.plant = false;
            MeshCollider piantinaManoCollider;
            piantinaManoCollider = piantinaMano.transform.GetComponent<MeshCollider>();
            piantinaManoCollider.enabled = true;
            piantinaMano.transform.position = new Vector3(control.transform.position.x, piantinaMano.transform.position.y, piantinaMano.transform.position.z);
            rbPersonaggio.isKinematic = false;
            rbPianta.isKinematic = false;
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = true;*/
        }
    }
}