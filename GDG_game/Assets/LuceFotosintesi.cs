using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class LuceFotosintesi : MonoBehaviour
    {
        public GameObject Piante;
        public ParticleSystem pS;
        public GameObject[] fog;
        public GameObject Player;
        
        

        // Start is called before the first frame update
        void Start()
        {
            fog = GameObject.FindGameObjectsWithTag("Fog");
            Player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<CharacterControl>().protectPlant)
            {
                if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
                {
                    Player.GetComponent<Animator>().SetBool("Move", true);
                    Debug.Log("fotosintesi");
                    Piante.GetComponent<MeshRenderer>().enabled = true;
                    Piante.GetComponent<Animator>().enabled = true;
                    Piante.GetComponent<Animator>().SetBool("fotosintesi", true);
                    pS.Play();
                    Player.GetComponent<Animator>().SetBool("Fotosintesi", true);
                }

                this.gameObject.GetComponent<AudioSource>().Play();
                StartCoroutine("Standing");

                for (int i = 0; i < fog.Length; i++)
                {

                    var main = fog[i].GetComponent<ParticleSystem>().main;
                    main.startColor = new Color(1f, 1f, 1f, .2f);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<CharacterControl>().protectPlant)
            {
                Piante.GetComponent<MeshRenderer>().enabled = false;
                Piante.GetComponent<Animator>().enabled = false;
                Piante.GetComponent<Animator>().SetBool("fotosintesi", false);
                pS.Stop();
                Destroy(this);
            }
        }

        IEnumerator Standing()
        {
            Debug.Log("Coroutine");
            yield return new WaitForSeconds(10f);
            Player.GetComponent<Animator>().SetBool("Move", false);
            Player.GetComponent<Animator>().SetBool("Fotosintesi", false);
        }
    }
}
