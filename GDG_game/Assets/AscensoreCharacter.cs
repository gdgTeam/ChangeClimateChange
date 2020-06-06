using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	public class AscensoreCharacter : MonoBehaviour
	{
		public GameObject montacarichi;
        public bool characterOn;

        public float piano_0;
        public float piano_1;
        public float piano_2;
        public float piano_3;
        public float piano_4;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
                characterOn = true;
			}
		}

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                characterOn = false;
            }
        }

        private void Update()
        {

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
