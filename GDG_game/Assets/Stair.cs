using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class Stair : MonoBehaviour
    {

        public bool ON;

        public static bool IsStair(GameObject obj)
        {
            if (obj.GetComponent<Stair>() == null)
            {
                return false;
            }
            return true;
        }
    }
}
