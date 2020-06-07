using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial {
    public class AscensoreOggetto : MonoBehaviour
    {
        public int pianoCorrente = 1;
        public float translation;
        public Transform ascensoreOggetto;
        public bool triggerEnter;

        private int nuovoPiano;
        private string interruttore;
        private CharacterControl control;
        private GameObject player;

        void Start()
        {
            triggerEnter = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (control != null)
            {
                control = player.GetComponent<CharacterControl>();
            }
            //checkInterruttoreAscensore();
            if (triggerEnter && control.Interact && (control.pianoAscensoreOggetto>0 || control.pianoAscensoreOggetto<5))
            {

                if (nuovoPiano < control.pianoAscensoreOggetto)
                {
                    Debug.Log("Scendo");
                    Debug.Log("Nuovo piano: " + nuovoPiano);
                    Debug.Log("Piano corrente" + control.pianoAscensoreOggetto);
                    ascensoreOggetto.localPosition = new Vector3(0,
                        ascensoreOggetto.localPosition.y - (translation*(control.pianoAscensoreOggetto - nuovoPiano)),
                        0);
                    control.pianoAscensoreOggetto = nuovoPiano;
                }
                else if (nuovoPiano > control.pianoAscensoreOggetto)
                {
                    Debug.Log("Salgo");
                    Debug.Log("Nuovo piano: " + nuovoPiano);
                    Debug.Log("Piano corrente" + control.pianoAscensoreOggetto);
                    ascensoreOggetto.localPosition = new Vector3(0,
                        ascensoreOggetto.localPosition.y + (translation * (nuovoPiano - control.pianoAscensoreOggetto)),
                        0);
                    control.pianoAscensoreOggetto = nuovoPiano;
                }
            }
        }

        private int checkInterruttoreAscensore()
        {
            //string interruttore = this.gameObject.transform.name;
            switch (interruttore)
            {
                case "Interruttore_1":
                    nuovoPiano = 1;
                    break;
                case "Interruttore_2":
                    nuovoPiano = 2;
                    break;
                case "Interruttore_3":
                    nuovoPiano = 3;
                    break;
                case "Interruttore_4":
                    nuovoPiano = 4;
                    break;
            }

            return nuovoPiano;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                interruttore = this.name;
                player = other.gameObject;
                control = other.gameObject.GetComponent<CharacterControl>();
                nuovoPiano = checkInterruttoreAscensore();
                triggerEnter = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                triggerEnter = false;
            }
        }

    }
}
