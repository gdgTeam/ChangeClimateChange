﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/LancioCorda")]
    public class LancioCorda : StateData
    {
        public CharacterControl control;
        public AudioClip clip;
        private LineRenderer rope;
        
        //public GameObject pianta;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool("LancioCorda", true);
            control = characterState.GetCharacterControl(animator);
           
            control.isSwinging = true;
            rope = control.transform.GetComponent<LineRenderer>();
            control.liana.transform.position = control.transform.position;
            control.liana.GetComponent<MeshRenderer>().enabled = true;
            control.liana.GetComponent<Animator>().enabled = true;
            control.liana.GetComponent<Animator>().SetBool("Liana", true);

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
            Vector3 ancoraggio = new Vector3(control.transform.position.x,
               control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.transform.position.y,
               control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.transform.position.z);
            /*GameObject connRB = control.transform.GetComponent<DistanceJoint3D>().ConnectedRigidbody.gameObject;
            connRB.AddComponent<AudioSource>().playOnAwake = false ;
            connRB.GetComponent<AudioSource>().clip = clip;
            connRB.GetComponent<AudioSource>().volume = 0.1f;
            Debug.Log("Rope lanciata");
            connRB.GetComponent<AudioSource>().Play();*/
            rope.SetPosition(1, ancoraggio);
            
        }
       
    }
}
