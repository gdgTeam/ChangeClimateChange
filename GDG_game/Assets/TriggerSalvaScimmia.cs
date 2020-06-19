using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class TriggerSalvaScimmia : MonoBehaviour
    {
        GameObject scimmia;
        // Start is called before the first frame update
        void Start()
        {
            scimmia = GameObject.FindGameObjectWithTag("Scimmia");
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Pushable")
            {
                
                scimmia.GetComponent<NavMesh2>().enabled = true;
                scimmia.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
        }
    }
}