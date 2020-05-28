using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/GrapplingHook")]
    public class GrapplingHook : StateData
    {
        private LineRenderer lr;
        private Vector3 grapplePoint;
        public LayerMask whatIsGrappable;
        public Transform StartRayCast;
        public float maxDistance = 100f;
        private SpringJoint joint;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            lr = control.GetComponent<LineRenderer>();
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            DrawRope();
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (Input.GetMouseButtonDown(0))
            {
                StartGrapple(control);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopGrapple();
            }

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        void StartGrapple(CharacterControl control)
        {
            RaycastHit hit;
            if(Physics.Raycast(control.transform.position, control.transform.forward, out hit, maxDistance))
            {
                grapplePoint = hit.point;
                joint = control.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(a: control.transform.position, b: grapplePoint);
               
                joint.maxDistance = distanceFromPoint * 0.8f;
                joint.minDistance = distanceFromPoint * 0.25f;

                joint.spring = 4.5f;
                joint.damper = 7f;
                joint.massScale =4.5f;
            }
            
        }
        void DrawRope()
        {
            lr.SetPosition(index: 0, StartRayCast.position);
            lr.SetPosition(index: 1, grapplePoint);
        }
        void StopGrapple()
        {

        }
    }
}
