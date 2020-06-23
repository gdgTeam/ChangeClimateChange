using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial {
    public class Trigger_inizioCitta : MonoBehaviour
    {
        private bool enter;

        private void Start()
        {
            enter = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!enter)
            {
                enter = true;
                FindObjectOfType<AudioManager>().StopPlaying("audio_foresta");
                FindObjectOfType<AudioManager>().Play("audio_citta");
            }
        }


    }
}
