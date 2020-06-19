using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Pull")]
    public class Pull : StateData
    {

        public AnimationCurve SpeedGraph;
        public float Speed;
        public float PushDistance;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PushDistance = 0f;
            CharacterControl control = characterState.GetCharacterControl(animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Interact && (control.MoveLeft || control.MoveRight)) { 

                if ((control.girato && control.MoveRight) || (!control.girato && control.MoveLeft)) {
                    //animator.SetBool(TransitionParameter.Pull.ToString(), true);
                    control.transform.
                        Translate(-Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Pull.ToString(), false);
                }
            }

            if (!control.Interact)
            {
                Debug.Log("Mollo l'oggetto dal PULL");
                animator.SetBool(TransitionParameter.Interact.ToString(), false);
                //return;
            }

            if (!control.MoveRight && !control.MoveLeft)
            {
                Debug.Log("Non PULLO più");
                animator.SetBool(TransitionParameter.Pull.ToString(), false);
                //return;
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckObjectFront(CharacterControl control, Animator animator)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, PushDistance)
                    && hit.collider.gameObject.tag == "PushableTree")
                {
                    return true;
                }
            }

            return false;
        }

    }
}
