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
        public bool OnPlace =false;
    public bool isTurning = false;
    public List<GameObject> BottomSpheres = new List<GameObject>();
    public List<GameObject> FrontSpheres = new List<GameObject>();
    public GameObject player;
    public int dir;
    public float offset;
    public bool fatto;
    public bool fatto2;
    public bool colliding;
   // public LineRenderer lr;
    void Start()
        {
       
        player = GameObject.FindGameObjectWithTag("Player");
        left = new Vector3(0, 180f, 0);
        right = new Vector3(0, 0, 0);
        hit = 0;
        // SetCollidersSpheres();
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
       /* if (lr != null)
        {
           
            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, this.transform.forward * 10f);
        }
        */
        if (OnPlace == true && !isTurning)
        {
            StartCoroutine(GiraSulPosto());
        }
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
    private IEnumerator GiraSulPosto()
    {
        isTurning = true;
        this.GetComponent<Animator>().SetBool("OnPlace", true);
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<Animator>().SetBool("OnPlace", false);
        yield return new WaitForSeconds(4f);
        isTurning = false;
        
    }
    public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresList)
    {
        for (int i = 0; i < interations; i++)
        {
            Vector3 pos = start.transform.position + (dir * sec * (i + 1));

            GameObject newObj = CreateEdgeSphere(pos);
            newObj.transform.parent = this.transform;
            spheresList.Add(newObj);
        }
    }
    public GameObject CreateEdgeSphere(Vector3 pos)
    {
        GameObject obj = Instantiate(this.EdgeCollider, pos, Quaternion.identity);
        return obj;
    }
    public void SetCollidersSpheresRight()
    {

        BoxCollider box = this.GetComponent<BoxCollider>();
        //box.transform.position = new Vector3(player.transform.position.x, box.transform.position.y, box.transform.position.z);
        float bottom = box.bounds.center.y - box.bounds.extents.y;
        float top = box.bounds.center.y + box.bounds.extents.y;
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;
        offset = Mathf.Abs(player.transform.position.x - this.transform.position.x);
        GameObject bottomFront = CreateEdgeSphere(new Vector3(this.transform.position.x+dir*offset, bottom, front));
        GameObject bottomBack = CreateEdgeSphere(new Vector3(this.transform.position.x+dir*offset, bottom, back));
        GameObject topFront = CreateEdgeSphere(new Vector3(this.transform.position.x+dir*offset, top, front));

        bottomFront.transform.parent = this.transform;
        bottomBack.transform.parent = this.transform;
        topFront.transform.parent = this.transform;

        BottomSpheres.Add(bottomFront);
        BottomSpheres.Add(bottomBack);

         FrontSpheres.Add(bottomFront);
         FrontSpheres.Add(topFront);

        float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
        CreateMiddleSpheres(bottomFront, -this.transform.forward, horSec, 4, BottomSpheres);

        float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
        CreateMiddleSpheres(bottomFront, this.transform.up, verSec, 9, FrontSpheres);
        fatto = true;

    }
    public void SetCollidersSpheresLeft()
    {
        
        BoxCollider box = this.GetComponent<BoxCollider>();
        //box.transform.position = new Vector3(player.transform.position.x, box.transform.position.y, box.transform.position.z);
        float bottom = box.bounds.center.y - box.bounds.extents.y;
        float top = box.bounds.center.y + box.bounds.extents.y;
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;
        offset = Mathf.Abs(player.transform.position.x - this.transform.position.x);
        GameObject bottomFront = CreateEdgeSphere(new Vector3(this.transform.position.x+offset, bottom, front));
        GameObject bottomBack = CreateEdgeSphere(new Vector3(this.transform.position.x+offset , bottom, back));
        GameObject topFront = CreateEdgeSphere(new Vector3(this.transform.position.x+offset, top, front));

        bottomFront.transform.parent = this.transform;
        bottomBack.transform.parent = this.transform;
        topFront.transform.parent = this.transform;

        BottomSpheres.Add(bottomFront);
        BottomSpheres.Add(bottomBack);

         FrontSpheres.Add(bottomFront);
         FrontSpheres.Add(topFront);

        float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
        CreateMiddleSpheres(bottomFront, -this.transform.forward, horSec, 4, BottomSpheres);

        float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
        CreateMiddleSpheres(bottomFront, this.transform.up, verSec, 9, FrontSpheres);
        fatto2 = true;
       

    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.gameObject.tag == "Pushable")
        {
            Debug.Log("collido");
            colliding = true;
        }
        else
            colliding = false;
            
    }
}

