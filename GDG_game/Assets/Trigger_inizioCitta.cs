using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial {
    public class Trigger_inizioCitta : MonoBehaviour
    {
        private bool enter;
        private GameObject RobotFor1;
        private GameObject RobotFor2;
        private GameObject RobotCitta;

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
                RobotFor1 = GameObject.Find("Robot(5)");
                RobotFor2 = GameObject.Find("Robot(6)");
                RobotCitta = GameObject.Find("Robot_(1)");
                RobotFor1.SetActive(false);
                RobotFor2.SetActive(false);
                RobotCitta.SetActive(true);
            }
        }


    }
}
