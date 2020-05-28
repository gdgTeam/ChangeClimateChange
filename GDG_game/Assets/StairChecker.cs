using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{


    public class StairChecker : MonoBehaviour
    {
        public bool StairVal;
        Stair CheckStair = null;
        public Stair foundedStair;



        private void OnTriggerEnter(Collider other)
        {
            CheckStair = other.gameObject.GetComponent<Stair>();
            if (CheckStair != null)
            {
                foundedStair = CheckStair;

                StairVal = CheckStair.ON;
                
                Debug.Log(foundedStair);


            }
        }

        private void OnTriggerExit(Collider other)
        {
            foundedStair = null;
            /*CheckStair = other.gameObject.GetComponent<Stair>();
            if (CheckStair != null)
            {
                StairVal = CheckStair.ON;
                
                
            }*/
        }

       
    }

}
