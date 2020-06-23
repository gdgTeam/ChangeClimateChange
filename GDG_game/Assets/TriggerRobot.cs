using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    
    public class TriggerRobot : MonoBehaviour
    { 

        private void OnTriggerEnter(Collider other)
        {
            //faccio fermare il robot
            if (other.transform.tag == "Robot")
            {
                Animator animator = other.gameObject.GetComponent<Animator>();
                if (animator.GetBool("Walk") && !animator.GetBool("CharacterDetected"))
                {

                    animator.SetBool("Walk", false);
                }
            }
        }
    }
}
