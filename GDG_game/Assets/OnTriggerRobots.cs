using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerRobots : MonoBehaviour
{
    public GameObject robot1;
    public GameObject robot2;
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
        Debug.Log(other);
        if (other.gameObject.tag=="Player")
        {
            if (robot1.GetComponent<RobotControl>().enabled)
            {
                robot1.GetComponent<RobotControl>().enabled = false;
                robot2.GetComponent<RobotControl>().enabled = true;
            }
            else
            {
                robot1.GetComponent<RobotControl>().enabled = true;
                robot2.GetComponent<RobotControl>().enabled = false;
            
            }
        }
    }

}
