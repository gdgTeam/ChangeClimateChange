using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class TriggerRamo : MonoBehaviour
    {
        bool fatto = false;
        int count;
        // Start is called before the first frame update
        void Start()
        {
            fatto = false;
        }

        // Update is called once per frame
        void Update()
        {
            count = this.transform.childCount;
            Debug.Log(count);
           
            if (fatto == true)
            {
                StartCoroutine(Cade());
               
            }
        }
      /*  private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && count == 0)
            {
                Debug.Log("iefnv");
                if (fatto == false)
                {
                    Debug.Log(this.transform.childCount);
                    other.transform.parent = null;
                    this.gameObject.AddComponent<Rigidbody>();
                    Rigidbody rb = this.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
                    this.GetComponent<Rigidbody>().useGravity = true;
                    fatto = true;
                }


            }
        }*/
        private void OnTriggerExit(Collider other)
        {
            if (fatto == false)
            {
                other.transform.parent = null;
                this.gameObject.AddComponent<Rigidbody>();
                Rigidbody rb = this.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
                this.GetComponent<Rigidbody>().useGravity = true;
                fatto = true;
            }
        }
        IEnumerator Cade()
        {
            yield return new WaitForSeconds(2f);
           // Destroy(this.GetComponent<Rigidbody>());
            Destroy(this.GetComponent<Ledge>());
            //this.transform.position = new Vector3(this.transform.position.x, 0f, this.transform.position.z);
        }

    }
}
