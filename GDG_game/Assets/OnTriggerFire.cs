using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{


    public class OnTriggerFire : MonoBehaviour
    {
        public bool fatto = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<CharacterControl>().CheckCorazza();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && !fatto)
            {
                other.GetComponent<CharacterControl>().CheckCorazza();
                //StartCoroutine("Fatto");
            }
        }

        private IEnumerator Fatto()
        {
            yield return new WaitForSeconds(1f);
            fatto = true;
        }
    }

}
