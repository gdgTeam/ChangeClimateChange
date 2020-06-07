using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuceFotosintesi : MonoBehaviour
{  
    public GameObject Piante;
    public ParticleSystem pS;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
