using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class CheckPoint : MonoBehaviour
    {
        private GameMaster gm;
        public GameObject sfondo;
        public GameObject robot7;
        public GameObject LuceFotosintesi;
        public GameObject[] fog;
        // Start is called before the first frame update
        void Start()
        {
            // sfondo = GameObject.FindGameObjectWithTag("Sfondo");

            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (sfondo != null && robot7 != null)
                {
                    robot7.SetActive(true);
                    sfondo.SetActive(true);
                }

                gm.lastCheckPointPose = new Vector3(other.transform.position.x, transform.position.y, transform.position.z);
                if (this.name == "Checkpoint8")
                {
                    other.GetComponent<CharacterControl>().passato = true;
                    
                }
                if(other.GetComponent<CharacterControl>().passato == true)
                fog = GameObject.FindGameObjectsWithTag("Fog");
                for (int i = 0; i < fog.Length; i++)
                {

                    var main = fog[i].GetComponent<ParticleSystem>().main;
                    main.startColor = new Color(1f, 1f, 1f, .1f);
                }


            }
        }


    }
}
