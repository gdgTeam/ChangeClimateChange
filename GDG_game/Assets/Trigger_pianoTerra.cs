using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class Trigger_pianoTerra : MonoBehaviour
    {
        public GameObject ascensore;
        public GameObject player;
        public GameObject colliderAscensore;
        public bool triggerEnter;

        private CharacterControl control;
        private bool startTranslation;
        private AscensoreCharacter ac;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            triggerEnter = false;
            startTranslation = false;
        }

        private void Update()
        {
            control = player.GetComponent<CharacterControl>();
            if(triggerEnter && control.Interact)
            {

                ac = colliderAscensore.GetComponent<AscensoreCharacter>();
                if (ac.pianoCorrente != 0)
                {
                    ac.resetAll();
                    startTranslation = true;
                    this.GetComponent<AudioSource>().Play();
                }
            }

            if (startTranslation && ascensore.transform.localPosition.y > 18189.56)
            {
                ac.muoviAscensore(0.2f);
            }
            else
            {
                this.GetComponent<AudioSource>().Stop();
                startTranslation = false;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                player = other.gameObject;
                triggerEnter = true;
        }

        public void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
                triggerEnter = false;
            
        }
    }
}
