using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Robot_CharacterDetection")]
    public class Robot_characterDetection : StateData
    {
        public bool playerDetected;
        private RobotControl control;
        public GameObject player;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerDetected = false;
            control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.EdgeCollider.transform.position.z);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.EdgeCollider.transform.position.z);
            if (playerDetected == false)
            {
                
                control = animator.GetComponentInParent<RobotControl>();
                playerDetected = checkFront(control);
                if (playerDetected)
                    animator.SetBool("CharacterDetected", true);
                else
                    animator.SetBool("CharacterDetected", false);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }


        private bool checkFront(RobotControl control)
        {
            RaycastHit hit;
            Debug.DrawRay(control.EdgeCollider.transform.position, control.transform.forward, Color.yellow);
            
            if (Physics.Raycast(control.EdgeCollider.gameObject.transform.position, control.transform.forward, out hit, 400f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("trovato");
                    return true;
                }
            }
            return false;
        }
    }
}
