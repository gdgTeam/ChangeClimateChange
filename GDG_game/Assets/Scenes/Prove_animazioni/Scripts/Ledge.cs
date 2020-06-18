using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class Ledge : MonoBehaviour
    {
        public Vector3 Offset;
        public Vector3 EndPosition;
        public GameObject player;
        
        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
          
        }
        public static bool IsLedge (GameObject obj)
        {
            if (obj.GetComponent<Ledge>()==null)
            {
                return false;
            }
            return true;
        }

        public void Update()
        {
            Offset.x =  0;
        }
    }

    
}