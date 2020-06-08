using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class TriggerLago : MonoBehaviour
    {
        Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Pushable")
            {
                rb = other.GetComponent<Rigidbody>();
                Destroy(rb);
                Debug.Log(other.gameObject);
                Destroy(other.gameObject.GetComponent<Ledge>());
                //other.transform.position = new Vector3(other.transform.position.x, this.transform.position.y-0.3f, other.transform.position.z);
            }
        }
    }
}
