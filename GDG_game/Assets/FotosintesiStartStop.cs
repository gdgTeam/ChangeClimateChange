using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotosintesiStartStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
