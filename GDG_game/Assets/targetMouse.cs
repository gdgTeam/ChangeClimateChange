using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMouse : MonoBehaviour
{
   public GameObject player;
    Vector3 pos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {

            this.transform.position = player.transform.position- new Vector3(0.5f ,0,0);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position - new Vector3(0.5f, 0, 0);

    }
}
