﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaino : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collider");

        if (col.gameObject.tag == "PushableTree")
        {
            this.gameObject.transform.SetParent(col.transform);
        }
    }
}
