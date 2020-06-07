using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuceFotosintesi : MonoBehaviour
{  
    public GameObject Piante;
    public ParticleSystem pS;
    public GameObject[] fog;

    // Start is called before the first frame update
    void Start()
    {
        fog = GameObject.FindGameObjectsWithTag("Fog");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject== GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("fotosintesi");
            Piante.GetComponent<MeshRenderer>().enabled = true;
            Piante.GetComponent<Animator>().enabled = true;
            Piante.GetComponent<Animator>().SetBool("fotosintesi", true);
            pS.Play(); 
        }

        for(int i = 0; i < fog.Length; i++)
        {

            var main = fog[i].GetComponent<ParticleSystem>().main;
            main.maxParticles = 100;
            main.startLifetime = 100;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            Piante.GetComponent<MeshRenderer>().enabled = false;
            Piante.GetComponent<Animator>().enabled = false;
            Piante.GetComponent<Animator>().SetBool("fotosintesi", false);
            pS.Stop();

        }
    }
}
