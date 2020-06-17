using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Robot_Detecter")]
    public class Robot_Detecter : StateData
    {
        public bool playerDetected;
        private RobotControl control;
        public GameObject player;
        

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
            // control = characterState.GetRobotControl(animator);
            control = animator.GetComponentInParent<RobotControl>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerDetected = false;
           
            // control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.EdgeCollider.transform.position.z);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            control = animator.GetComponentInParent<RobotControl>();
           
            // control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.transform.position.z);
            
                control = animator.GetComponentInParent<RobotControl>();
                playerDetected = checkFront(control);
            Debug.Log(playerDetected);
            if (playerDetected)
               
                    animator.SetBool("CharacterDetected", true);
            else if (!playerDetected)
            {
                    Debug.Log("Jhbbhj");
                    animator.SetBool("CharacterDetected", false);
                    control.OnPlace = true;
                    animator.SetBool("Walk", false);
                }
                    
            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }


       /* private bool checkFront(RobotControl control)
        {
            RaycastHit hit;
            Debug.DrawRay(control.EdgeCollider.transform.position, control.transform.forward, Color.yellow);

            if (Physics.Raycast(control.EdgeCollider.gameObject.transform.position, control.transform.forward, out hit, 700f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("trovato");
                    return true;
                }
            }
            return false;
        }*/
        
        bool checkFront(RobotControl control)
        {
            Debug.Log("check");

            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.Log(o);
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.2f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, 50f))
                {

                    if (hit.collider.gameObject.tag == "Player")
                    {
                        Debug.Log("trovato");
                        return true;
                    }
                    
                  

                }
                
            }
            return false;
        }
    }
}
