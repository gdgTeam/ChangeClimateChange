using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class TriggerAcqua : MonoBehaviour
    {
        public AudioClip nuotata;
        public AudioClip uscita;
        public AudioSource audio;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                audio = GetComponent<AudioSource>();
                audio.volume = 1;
                audio.clip = nuotata;
                GetComponent<AudioSource>().Play();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
            {
                audio = GetComponent<AudioSource>();
                audio.clip = uscita;
                audio.volume = 0.9f;
                audio.Play();
            }
        }
    }
}
