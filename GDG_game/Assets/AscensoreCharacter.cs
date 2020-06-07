using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	public class AscensoreCharacter : MonoBehaviour
	{
	
        public GameObject Ascensore;
        public GameObject Character;

        public bool characterOn;
        public int pianoCorrente;
        public float piano_0;
        public float piano_1;
        public float piano_2;
        public float piano_3;
        public float piano_4;

        private CharacterControl control;
        private bool wait;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
                Character = other.gameObject;
                Debug.Log(Character);
                control = Character.GetComponent<CharacterControl>();
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

        private void Start()
        {
            //parto dal piano terra
            //this.transform.position = new Vector3(this.transform.position.x, piano_0, this.transform.position.z);
            Ascensore.transform.localPosition = new Vector3(0, piano_0, 0);
            pianoCorrente = 0;
            wait = false;

        }

        private void Update()
        {
            int nuovoPiano = checkInteractionAscensore();
            if (nuovoPiano != -1)
            {
                //faccio scendere o salire l'ascensore
                switch (nuovoPiano)
                {
                    case 0:
                        Ascensore.transform.localPosition = new Vector3(0, piano_0, 0);
                        break;
                    case 1:
                        Ascensore.transform.localPosition = new Vector3(0, piano_1, 0);
                        break;
                    case 2:
                        Ascensore.transform.localPosition = new Vector3(0, piano_2, 0);
                        break;
                    case 3:
                        Ascensore.transform.localPosition = new Vector3(0, piano_3, 0);
                        break;
                    case 4:
                        Ascensore.transform.localPosition = new Vector3(0, piano_4, 0);
                        break;
                }
            }
            else
            {
                wait = false;
            }
        }

        IEnumerator Animation(Collider o)
		{
			Ascensore.GetComponent<Animation>().Play();

			yield return new WaitForSeconds(1.9f);
			o.GetComponent<Rigidbody>().useGravity = true;
			o.GetComponent<Rigidbody>().isKinematic = false;
			o.gameObject.transform.parent = null;

		}

		private int checkInteractionAscensore()
        {
            if (control != null && !wait)
            {
                if (control.MoveDown && pianoCorrente != 0)
                {
                    pianoCorrente--;
                    wait = true;
                    Character.transform.SetParent(Ascensore.transform);
                    return pianoCorrente;

                }
                else if (control.MoveUp && pianoCorrente != 4)
                {
                    pianoCorrente++;
                    wait = true;
                    Character.transform.SetParent(Ascensore.transform);
                    return pianoCorrente;
                }

            }
            return -1;
        }


	}
}
