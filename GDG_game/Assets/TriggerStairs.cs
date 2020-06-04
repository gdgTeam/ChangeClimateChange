using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStairs : MonoBehaviour
{
    public GameObject gradino1;
    public GameObject gradino2;
    public GameObject scala;
    private bool piccolo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            this.GetComponentInParent<Animator>().enabled = true;
            StartCoroutine(CadutaGradino());
        }
    }

    IEnumerator CadutaGradino()
    {
        
        yield return new WaitForSeconds(4f);
        this.GetComponent<Rigidbody>().useGravity = true;
        gradino1.GetComponent<Rigidbody>().useGravity = true;
        gradino2.GetComponent<Rigidbody>().useGravity = true;
        if (piccolo == false)
        {
            scala.GetComponent<Animation>().Play();

            piccolo = true;
           
        }
        this.GetComponentInParent<Animator>().enabled = false;

    }
}
