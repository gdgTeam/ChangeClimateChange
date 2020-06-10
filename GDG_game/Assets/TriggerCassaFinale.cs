using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class TriggerCassaFinale : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Pushable")
            {
                Rigidbody rg = other.transform.GetComponent<Rigidbody>();
                rg.isKinematic = true;
            }
        }
    }
}

