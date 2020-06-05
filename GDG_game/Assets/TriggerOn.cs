using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class TriggerOn : MonoBehaviour
    {
        public GameObject montacarichi;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.transform.parent = montacarichi.gameObject.transform;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                StartCoroutine(Animation(other));
               

            }
        }
        IEnumerator Animation(Collider o)
        {
            montacarichi.GetComponent<Animation>().Play();

            yield return new WaitForSeconds(1.9f);
            o.GetComponent<Rigidbody>().useGravity = true;
            o.GetComponent<Rigidbody>().isKinematic = false;
            o.gameObject.transform.parent = null;

        }

        // Update is called once per frame
       
       
    }
}
