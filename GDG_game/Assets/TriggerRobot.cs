﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    
    public class TriggerRobot : MonoBehaviour
    { 

        private void OnTriggerEnter(Collider other)
        {
            //faccio fermare il robot
            Animator animator = other.gameObject.GetComponent<Animator>();
            if (animator.GetBool("Walk"))
            {
                Debug.Log("non cammino");  
                animator.SetBool("Walk", false);
            }
        }
    }
}
