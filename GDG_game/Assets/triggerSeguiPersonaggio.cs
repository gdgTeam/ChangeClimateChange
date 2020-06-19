using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class triggerSeguiPersonaggio : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(this.name);
            if (other.gameObject.tag == "Scimmia")
            {
                other.GetComponent<NavMesh2>().enabled = false;
                other.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                other.GetComponent<FollowTargetScimmia>().enabled = true;
            }
        }
    }
}
