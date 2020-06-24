﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Robot_Run")]
    public class Robot_run : StateData
    {
        private RobotControl control;
        public float Speed;
        public AnimationCurve SpeedGraph;
        private GameObject player;
        public AudioClip clip;
        private AudioSource audio;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           // player = control.player;
            player = GameObject.FindGameObjectWithTag("Player");
            audio = animator.GetComponentInParent<RobotControl>().gameObject.GetComponent<AudioSource>();
            audio.clip = clip;
            audio.loop = true;
            audio.Play();
           // animator.transform.position = new Vector3(animator.transform.position.x, 3.65f, animator.transform.position.z);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           // player = control.player;
            //animator.transform.position = new Vector3(animator.transform.position.x, 3.65f, animator.transform.position.z);
            control = animator.GetComponentInParent<RobotControl>();
            if (control.MoveRight)
            {
                Vector3 targetDirection = player.transform.position - control.transform.position;
                Vector3 diff = control.transform.position - player.transform.position;
                targetDirection.y = 0f;
                targetDirection.Normalize();
                control.transform.Translate(targetDirection * 6.5f * Time.deltaTime);
                Debug.Log(targetDirection);
                if (diff.z < 1f || control.colliding)
                {
                    animator.SetBool("CharacterDetected", false);
                    animator.SetBool("Walk", false);
                    player.GetComponent<Animator>().SetBool("FallToDie", true);
                }
            }

            if (control.MoveLeft)
            {
                Vector3 targetDirection = control.transform.position - player.transform.position;
                Vector3 diff= control.transform.position - player.transform.position;
                targetDirection.y = 0f;
                targetDirection.Normalize();
                control.transform.Translate(targetDirection * 6.5f * Time.deltaTime);
                
                if (diff.z < 1.5f || control.colliding)
                {

                   animator.SetBool("CharacterDetected", false);
                   animator.SetBool("Walk", false);
                    if(player.GetComponent<CharacterControl>().Die==false)
                   player.GetComponent<Animator>().SetBool("FallToDie", true);

                }
            }

           




        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            audio.Stop();

        }
    }
}
