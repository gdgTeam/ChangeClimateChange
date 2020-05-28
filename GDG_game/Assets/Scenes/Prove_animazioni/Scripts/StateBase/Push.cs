using System.Collections;
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
        private GameObject pushableTree;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            PushDistance = 0.5f;
            CharacterControl control = characterState.GetCharacterControl(animator);
            tree = CheckObjectFront(control, animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Pushing)
            {
                animator.SetBool(TransitionParameter.Push.ToString(), true);
                control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                /*if (tree)
                {
                    pushableTree.transform.Rotate(new Vector3(-10f, 0, 0) * Time.deltaTime, Space.Self);
                    Debug.Log("rotazioneAlbero");
                }*/
            }

            if (!control.Pushing)
            {
                animator.SetBool(TransitionParameter.Push.ToString(), false);
                return;
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
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, PushDistance) && hit.collider.gameObject.tag == "PushableTree")
                {
                    pushableTree = hit.collider.gameObject;
                    Debug.Log(hit.collider.gameObject);
                    return true;
                }
            }

            return false;
        }

    }
}