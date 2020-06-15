using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class RobotControl : MonoBehaviour
    {
        public bool Moving;
        public bool MoveLeft;
        public bool MoveRight;
        public bool Stopping;
        public bool Turning;
        public GameObject EdgeCollider;

        private Vector3 left;
        private Vector3 right;


        void Start()
        {
            left = new Vector3(0, 180f, 0);
            right = new Vector3(0, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            if(this.gameObject.transform.rotation.eulerAngles == left)
            {
                MoveLeft = true;
                MoveRight = false;
            }
            else if(this.gameObject.transform.rotation.eulerAngles == right)
            {
                MoveRight = true;
                MoveLeft = false;
            }
        }
    }
}
