using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scala2 : MonoBehaviour
{
    public GameObject scala;
    bool fatto;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        fatto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == this.transform.childCount && fatto == false)
        {
            scala.GetComponent<Animation>().Play();
            fatto = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Transform child in this.transform)
            {
               
                StartCoroutine(CadeGradino(child));
                
            }
           
        }
    }

    IEnumerator CadeGradino(Transform c)
    {

        yield return new WaitForSeconds(1.5f);
        c.gameObject.AddComponent<Rigidbody>();
        c.gameObject.AddComponent<BoxCollider>();
        c.gameObject.GetComponent<Rigidbody>().useGravity = true;
        count++;
        yield return new WaitForSeconds(2f);
       

    }
}
