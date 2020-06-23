using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{

    public class TriggerCassa : MonoBehaviour
    {
        public bool cassa;

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "PushableCassa")
            {
                cassa = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "PushableCassa")
            {
                cassa = false;
            }
        }
    }
}
