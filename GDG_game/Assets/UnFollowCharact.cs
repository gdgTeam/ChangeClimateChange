using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class UnFollowCharact : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Scimmia")
            {
                other.GetComponent<FollowTargetScimmia>().enabled = false;
                other.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                other.GetComponent<CharacterNavController>().enabled = true;
            }
        }
    }
}
