using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    private GameObject sfondo;
    public GameObject robot7;
    // Start is called before the first frame update
    void Start()
    {
        sfondo = GameObject.FindGameObjectWithTag("Sfondo");
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            robot7.SetActive(true);
            sfondo.SetActive(true);
            gm.lastCheckPointPose = new Vector3(other.transform.position.x,transform.position.y,transform.position.z);

        }
    }
   
    
}
