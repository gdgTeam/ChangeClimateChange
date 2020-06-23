﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Push")]
    public class Push : StateData
    {

        public AnimationCurve SpeedGraph;
        public float Speed;
        public float PushDistance;
        private bool tree = false;
        private GameObject pushableCassa;
        private AudioManager am;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PushDistance = 0.5f;
            CharacterControl control = characterState.GetCharacterControl(animator);
            tree = CheckObjectFront(control, animator);
            am = control.GetAudioManager();
            am.Play("Push");
            if (CheckObjectFront(control, animator))
            {
                pushableCassa.GetComponent<Rigidbody>().isKinematic = false;
            }
            
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Interact && (control.MoveLeft || control.MoveRight))
            {
                if ((control.girato && control.MoveLeft) || (!control.girato && control.MoveRight))
                {
                    control.transform.
                        Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Push.ToString(), false);
                }
            }

            if (!control.Interact)
            {
                animator.SetBool(TransitionParameter.Interact.ToString(), false);
                //return;
            }

            if (!control.MoveRight && !control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Push.ToString(), false);
                //return;
            }

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            am.StopPlaying("Push");
            if (pushableCassa != null)
                pushableCassa.GetComponent<Rigidbody>().isKinematic = true;
        }

        bool CheckObjectFront(CharacterControl control, Animator animator)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, PushDistance) && hit.collider.gameObject.tag == "PushableCassa")
                {
                    
                    pushableCassa = hit.collider.gameObject;
                    return true;
                }
            }

            return false;
        }

    }
}