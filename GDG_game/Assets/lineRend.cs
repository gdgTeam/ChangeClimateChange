using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRend : MonoBehaviour
{
    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(1, this.transform.parent.position);
        lr.SetPosition(0, this.transform.parent.transform.forward * 10f) ;
    }
}
