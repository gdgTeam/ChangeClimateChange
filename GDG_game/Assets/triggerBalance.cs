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
                if (On == true)
                {
                    if (other.gameObject.GetComponent<CharacterControl>().girato == false)
                    {
                        other.GetComponent<CharacterControl>().gru = On;
                    }
                    else
                    {
                        other.GetComponent<CharacterControl>().gru = false;
                    }
                }
                else
                {
                    if (other.gameObject.GetComponent<CharacterControl>().girato == false)
                    {
                        other.GetComponent<CharacterControl>().gru = On;
                    }
                    else
                    {
                        other.GetComponent<CharacterControl>().gru = true;
                    }
                }
              
            }
        }
    }
}
