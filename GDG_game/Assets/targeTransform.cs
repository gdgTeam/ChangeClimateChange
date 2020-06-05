using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeTransform : MonoBehaviour
{
    public GameObject player;
    float pos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //pos = player.transform.position.x;
            this.transform.position = new Vector3(player.transform.position.x -0.5f, this.transform.position.y, this. transform.position.z);

        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x - 0.5f, this.transform.position.y, this.transform.position.z);

    }
}

