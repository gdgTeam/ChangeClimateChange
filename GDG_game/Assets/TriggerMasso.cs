using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class TriggerMasso : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Robot")
            {
                // other.GetComponent<RobotControl>().TurnOnRagdoll();
                other.GetComponent<Animator>().SetBool("Die", true);
               // StartCoroutine(ToggleRagDoll(other));
            }
            if (other.gameObject.tag == "Pavimento")
            {
                // other.GetComponent<RobotControl>().TurnOnRagdoll();
                //this.GetComponent<Rigidbody>().useGravity = false;
                //this.GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                // StartCoroutine(ToggleRagDoll(other));
            }
        }
       
    }
}