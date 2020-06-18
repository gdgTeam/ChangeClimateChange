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
        bool preso;
        LineRenderer lr;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
           
            preso = false;
            playerDetected = false;
            // control = characterState.GetRobotControl(animator);
            control = animator.GetComponentInParent<RobotControl>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerDetected = checkFront(control);

            // control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.EdgeCollider.transform.position.z);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {


            Debug.Log("preso:" +  preso);
            Debug.Log("pD :" + playerDetected);
            control = animator.GetComponentInParent<RobotControl>();
           
            // control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.transform.position.z);
            
                control = animator.GetComponentInParent<RobotControl>();
                playerDetected = checkFront(control);

            if ( playerDetected||preso)
            {
                
                animator.SetBool("CharacterDetected", true);
            }
            else if (!playerDetected && !preso)
            {

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
            
            
           
           // Debug.DrawRay(control.transform.position, control.transform.forward * 10f, Color.red);
            foreach (GameObject o in control.FrontSpheres)
            {
                
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, 10f))
                {
                    
                   
                    if (!preso)
                    {
                        

                        if (hit.collider.gameObject.tag == "Player")
                        {

                           
                            bool interact = hit.collider.gameObject.GetComponent<CharacterControl>().Interact;
                            bool movingR = hit.collider.gameObject.GetComponent<CharacterControl>().MoveRight;
                            bool movingL = hit.collider.gameObject.GetComponent<CharacterControl>().MoveLeft;
                            if (interact)
                            {
                               
                                if (movingR || movingL)
                                {
                                    preso = true;
                                   
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }

                            }
                            else
                            {
                                preso = true;
                                return true;
                            }

                        }



                    }
                   

                }
                
            }
            return false;

        }
    }
}
