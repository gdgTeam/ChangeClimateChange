﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PickUp")]
    public class PickUp : StateData
    {
        public GameObject piantina;
        public GameObject troncoAcqua;
        CharacterControl control;
        private Rigidbody rbPianta;
        private Rigidbody rbPersonaggio;
        //public GameObject piantinaSpalla;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            piantina = GameObject.Find("zaino+pianta");
            piantina.transform.parent = null;
            rbPersonaggio = control.transform.GetComponent<Rigidbody>();
            rbPianta = piantina.transform.GetComponent<Rigidbody>();
            rbPersonaggio.isKinematic = true;
            rbPianta.isKinematic = true;
            if(control.PickPlant == true)
            {
                piantina.transform.SetParent(GameObject.Find("mixamorig:RightHand").transform);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.PickUp.ToString(), false);
            MeshRenderer piantinaManoMesh;
            BoxCollider piantinaManoCollider;
            piantinaManoMesh = piantina.transform.GetComponent<MeshRenderer>();
            piantinaManoMesh.enabled = false;
            piantinaManoMesh = piantina.transform.GetChild(0).gameObject.transform.GetComponent<MeshRenderer>();
            piantinaManoMesh.enabled = false;
            piantinaManoCollider = piantina.transform.GetComponent<BoxCollider>();
            piantinaManoCollider.enabled = false;
            control.gameObject.transform.GetChild(3).gameObject.transform.GetComponent<SkinnedMeshRenderer>().enabled = true;
            control.gameObject.transform.GetChild(2).gameObject.transform.GetComponent<SkinnedMeshRenderer>().enabled = true;
            control.plant = true;
            rbPersonaggio.isKinematic = false;
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = true;*/
        }
    }
}
