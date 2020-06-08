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

        private float newPiano;

        private CharacterControl control;
        private bool wait;
        public bool sali;
        public bool scendi;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
                Character = other.gameObject;
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
            Ascensore.transform.localPosition = new Vector3(0, piano_0, 0);
            pianoCorrente = 0;
            wait = false;
            scendi = false;
            sali = false;

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
                        newPiano = piano_0;
                        nuovoPiano = -1;
                        break;
                    case 1:
                        newPiano = piano_1;
                        nuovoPiano = -1;
                        break;
                    case 2:
                        newPiano = piano_2;
                        nuovoPiano = -1;
                        break;
                    case 3:
                        newPiano = piano_3;
                        nuovoPiano = -1;
                        break;
                    case 4:
                        newPiano = piano_4;
                        nuovoPiano = -1;
                        break;
                }
            }
            else
            {
                //wait = false;
            }
            if (wait)
            {
                if (scendi && Ascensore.transform.localPosition.y > newPiano)
                {
                    Debug.Log("sto scendendoooooo");
                    muoviAscensore(0.2f);
                }
                else if (sali && Ascensore.transform.localPosition.y < newPiano)
                {
                    Debug.Log("salgooooo");
                    muoviAscensore(-0.2f);
                }
                else
                {
                    Debug.Log("sono dentrooooooo");
                    Debug.Log(sali);
                    sali = false;
                    scendi = false;
                    wait = false;
                }
            }
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
                    scendi = true;
                    return pianoCorrente;
                }
                else if (control.MoveUp && pianoCorrente != 4)
                {
                    pianoCorrente++;
                    wait = true;
                    sali = true;
                    Character.transform.SetParent(Ascensore.transform);
                    return pianoCorrente;
                }
            }
            return -1;
        }

        private void muoviAscensore(float passo)
        {
            Ascensore.transform.Translate(0, passo, 0);
        }
	}
}
