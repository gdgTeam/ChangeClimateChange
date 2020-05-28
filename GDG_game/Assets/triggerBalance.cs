using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class triggerBalance : MonoBehaviour
    {
        public bool On;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<CharacterControl>().gru = On;
            }
        }
    }
}
