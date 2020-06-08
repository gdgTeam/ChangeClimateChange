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
        private bool altezzaCalcolata;
        private float nuovaAltezza;
        private bool scendi;
        private bool sali;

        void Start()
        {
            triggerEnter = false;
            altezzaCalcolata = false;
            nuovaAltezza = ascensoreOggetto.localPosition.y;
        }

        // Update is called once per frame
        void Update()
        {
            if (control != null)
            {
                control = player.GetComponent<CharacterControl>();
            }

            if (triggerEnter && control.Interact && (control.pianoAscensoreOggetto>0 || control.pianoAscensoreOggetto<5))
            {

                //discesa
                if (nuovoPiano < control.pianoAscensoreOggetto && !altezzaCalcolata)
                {
                    nuovaAltezza = ascensoreOggetto.localPosition.y -
                        (translation * (control.pianoAscensoreOggetto - nuovoPiano));
                    control.pianoAscensoreOggetto = nuovoPiano;
                    altezzaCalcolata = true;
                    scendi = true;
                }
                //salita
                if (nuovoPiano > control.pianoAscensoreOggetto && !altezzaCalcolata)
                {
                    nuovaAltezza = ascensoreOggetto.localPosition.y +
                        (translation * (nuovoPiano - control.pianoAscensoreOggetto));
                    control.pianoAscensoreOggetto = nuovoPiano;
                    altezzaCalcolata = true;
                    sali = true;
                }
            }

            if (altezzaCalcolata)
            {
                if (ascensoreOggetto.localPosition.y > nuovaAltezza && scendi)
                {
                    ascensoreOggetto.Translate(new Vector3(0, 0.2f, 0));
                }
                else if (ascensoreOggetto.localPosition.y < nuovaAltezza && sali)
                {
                    ascensoreOggetto.Translate(new Vector3(0, -0.2f, 0));
                }
                else
                {
                    altezzaCalcolata = false;
                    sali = false;
                    scendi = false;
                }
            }
        }

        private int checkInterruttoreAscensore()
        {
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
