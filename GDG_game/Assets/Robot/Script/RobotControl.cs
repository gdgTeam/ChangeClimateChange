using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RobotControl : MonoBehaviour
    {
        public bool Moving;
        public bool MoveLeft;
        public bool MoveRight;
        public bool Stopping;
        public bool Turning;
        public GameObject EdgeCollider;
        private Rigidbody RIGID_BODY;
        private Vector3 left;
        private Vector3 right;
        public List<Collider> RagdollParts = new List<Collider>();
        public int hit;

        void Start()
        {
            left = new Vector3(0, 180f, 0);
            right = new Vector3(0, 0, 0);
            hit = 0;
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
            SetRagdollParts();
        }
        private void SetRagdollParts()
        {
            Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in colliders)
            {
                if (c.gameObject != this.gameObject)
                {
                    c.isTrigger = true;
                    RagdollParts.Add(c);
                }

            }
        }
        public void TurnOnRagdoll()
        {
            RIGID_BODY = this.gameObject.GetComponent<Rigidbody>();
            RIGID_BODY.useGravity = false;
            RIGID_BODY.velocity = Vector3.zero;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<Animator>().avatar = null;
            foreach (Collider c in RagdollParts)
            {

                c.enabled = true;
                c.isTrigger = false;
                c.attachedRigidbody.velocity = Vector3.zero;
            }
        }
    }

