using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial { 
public class FollowTargetScimmia : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float movSpeed = 4f;

    public GameObject target;
    public Vector3 offset = new Vector3(0f, 0, 3f);
    private float val=1;
    // Start is called before the first frame update
    void Start()
    {
        
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
           
        //Compute target direction
        Vector3 targetDirection = target.transform.position+ val* offset - transform.position;
        targetDirection.y = 0f;
        targetDirection.Normalize();
            

        /*if (targetDirection.z < -0.3f)
            {
                movSpeed = 4f;
                Debug.Log("ciao");
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);
               // val = -1;
            }
            else if (targetDirection.z >= 0f)
            {
                Debug.Log("magg");
                if (target.transform.position.z - offset.z < this.transform.position.z)
                {
                    movSpeed = 4f;
                    Debug.Log(targetDirection.z);
                    //offset.z *= -1f;
                    this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);
                   // val = -1;
                    
                }
            }*/

            if(Mathf.Abs(target.transform.position.z -this.transform.position.z) > 3f && target.GetComponent<CharacterControl>().girato == false){
               
                    this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);
                    this.GetComponent<Animator>().SetBool("Walk", true);
                

            }
            else if (Mathf.Abs(target.transform.position.z - this.transform.position.z) > 3f && target.GetComponent<CharacterControl>().girato == true)
            {
                
                    this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);
                    this.GetComponent<Animator>().SetBool("Walk", true);
                

            }
            else if(Mathf.Abs(target.transform.position.z - this.transform.position.z) < 2.9f || target.GetComponent<Animator>().GetBool("Move")==false)
            {
                
                this.GetComponent<Animator>().SetBool("Walk", false);
            }



            //Rotate toward target direction
            /* float rotationStep = rotationSpeed * Time.deltaTime;
         Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationStep, 0.0f);
         transform.rotation = Quaternion.LookRotation(newDirection, transform.up);*/

            //Move object along its forward axis

            //IS EQUIVALENT TO 
            //transform.Translate(transform.forward * movSpeed * Time.deltaTime, Space.World);
        }

}
}
