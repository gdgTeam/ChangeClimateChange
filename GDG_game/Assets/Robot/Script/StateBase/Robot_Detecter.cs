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
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            // control = characterState.GetRobotControl(animator);
            control = animator.GetComponentInParent<RobotControl>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerDetected = false;
            SetCollidersSpheres();
            // control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.EdgeCollider.transform.position.z);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            control = animator.GetComponentInParent<RobotControl>();
            control.EdgeCollider.transform.position = new Vector3(player.transform.position.x, control.EdgeCollider.transform.position.y, control.transform.position.z);
            if (playerDetected == false)
            {

                control = animator.GetComponentInParent<RobotControl>();
                playerDetected = CheckFrontRobot(control);
                if (playerDetected)
                    animator.SetBool("CharacterDetected", true);
                else
                {
                    animator.SetBool("CharacterDetected", false);
                    control.OnPlace = true;
                    animator.SetBool("Walk", false);
                }
                    
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
        public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresList)
        {
            for (int i = 0; i < interations; i++)
            {
                Vector3 pos = start.transform.position + (dir * sec * (i + 1));

                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = control.transform;
                spheresList.Add(newObj);
            }
        }
        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(control.EdgeCollider, pos, Quaternion.identity);
            return obj;
        }
        private void SetCollidersSpheres()
        {
            BoxCollider box = control.GetComponent<BoxCollider>();

            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(control.transform.position.x, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(control.transform.position.x, bottom, back));
            GameObject topFront = CreateEdgeSphere(new Vector3(control.transform.position.x, top, front));

            bottomFront.transform.parent = control.transform;
            bottomBack.transform.parent = control.transform;
            topFront.transform.parent = control.transform;

            BottomSpheres.Add(bottomFront);
            BottomSpheres.Add(bottomBack);

            FrontSpheres.Add(bottomFront);
            FrontSpheres.Add(topFront);

            float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
            CreateMiddleSpheres(bottomFront, -control.transform.forward, horSec, 4, BottomSpheres);

            float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
            CreateMiddleSpheres(bottomFront, control.transform.up, verSec, 9, FrontSpheres);

        }
        bool CheckFrontRobot(RobotControl control)
        {
            foreach (GameObject o in FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, 100f))
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
