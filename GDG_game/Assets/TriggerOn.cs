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
                montacarichi.gameObject.AddComponent<Rigidbody>();
                montacarichi.GetComponent<Rigidbody>().mass = 10f;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
       
    }
}
