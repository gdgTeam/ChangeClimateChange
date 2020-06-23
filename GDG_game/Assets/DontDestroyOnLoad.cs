using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if(this.gameObject.tag!="Pushable")
            DontDestroyOnLoad(this);
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
