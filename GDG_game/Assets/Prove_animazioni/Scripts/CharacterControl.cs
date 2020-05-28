using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
        Grounded,
        Push,
        TransitionIndex,
        PickUp,
        Movedown,
        WalkUpStairs,
        PickDown,
        BalanceWalk,
        Spiderman,
        Die
        MoveBackward

    }

    public class CharacterControl : MonoBehaviour
    {
        public Vector3 scale= new Vector3();
        public Animator SkinnedMeshAnimator;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Pushing;
        public bool Picking;
        public bool PickingDown;
        public bool PickPlant;
        public bool LookRight;
        public bool LookLeft;
        public bool plant = false;
        public bool Shielding;
        private bool protectShield;
        public GameObject ColliderEdgePrefab;
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();
        public bool MoveUp;
        public bool MoveDown;
        public LedgeChecker ledgeChecker;
        public List<Collider> RagdollParts = new List<Collider>();
        public float GravityMultiplier;
        public float PullMultiplier;
        public bool grabCharact;
        public bool WalkUpStair;
        private Rigidbody rigid;
        public StairChecker stairChecker;
        public GameObject Corazza;
        public bool gru;
        public bool Spiderman;

        public Rigidbody RIGID_BODY
        {
            get
            {
                if (rigid == null)
                {
                    rigid = GetComponent<Rigidbody>();
                }
                return rigid;
            }
        }
        private void Start()
        {
            scale = this.transform.localScale;

        }

        private void Update()
        {
            if (ledgeChecker.IsGrabbingLedge == true)
            {
                grabCharact = true;

            }
            if (ledgeChecker.IsGrabbingLedge == false)
            {
                grabCharact = false;
               
            }
            if (MoveDown == true)
            {
             
             SkinnedMeshAnimator.SetBool(TransitionParameter.Movedown.ToString(), true);
            this.RIGID_BODY.useGravity = true;
            this.GetComponent<BoxCollider>().enabled = true;

            }
            else if(MoveDown==false)
            {
                SkinnedMeshAnimator.SetBool(TransitionParameter.Movedown.ToString(), false);
            }
            if (stairChecker.StairVal == true)
            {
                Debug.Log("true");
                WalkUpStair = true;

            }
            if (stairChecker.StairVal == false)
            {
                Debug.Log("false");

                WalkUpStair = false;

            }

            if (Shielding && protectShield)
            {
                protectShield = false;
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = true;
            }
            if (!Shielding && !protectShield)
            {
                protectShield = true;
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = false;
            }
            if(gru == true)
            {
                SkinnedMeshAnimator.SetBool(TransitionParameter.BalanceWalk.ToString(), true);
            }
            if (gru == false)
            {
                SkinnedMeshAnimator.SetBool(TransitionParameter.BalanceWalk.ToString(), false);
            }
            if (Spiderman == true)
            {
                SkinnedMeshAnimator.SetBool(TransitionParameter.Spiderman.ToString(), true);
            }
            if (Spiderman == false)
            {
                SkinnedMeshAnimator.SetBool(TransitionParameter.Spiderman.ToString(), false);
            }
        }

        private void Awake()
        {
            //SetRagdollParts();
            SetCollidersSpheres();   
        
        }

        private void SetRagdollParts()
         {
             Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
             foreach (Collider c in colliders)
             {
                 if(c.gameObject != this.gameObject)
                 {
                     c.isTrigger = true;
                     RagdollParts.Add(c);
                 }

             }
         }



        private void OnTriggerEnter(Collider col)
         {

             /*{
                 return;
             }*/
             if (col.gameObject.tag== "Pericolo")
             {
                 TurnOnRagdoll();
             }
             if(col.gameObject.tag == "Fire")
             {
                CheckCorazza();
             }
        }
         public void TurnOnRagdoll()
         {
             RIGID_BODY.useGravity = false;
             RIGID_BODY.velocity = Vector3.zero;
             this.gameObject.GetComponent<BoxCollider>().enabled = false;
             SkinnedMeshAnimator.enabled = false;
             SkinnedMeshAnimator.avatar = null;
             foreach( Collider c in RagdollParts)
             {
                 c.isTrigger = false;
                 c.attachedRigidbody.velocity = Vector3.zero;
             }
         }

        public void CheckCorazza()
        {
            if (protectShield)
            {
                SkinnedMeshAnimator.SetBool(TransitionParameter.Die.ToString(), true);
            }
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
        private void SetCollidersSpheres()
        {
            BoxCollider box = GetComponent<BoxCollider>();

            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(this.transform.position.x, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(this.transform.position.x, bottom, back));
            GameObject topFront = CreateEdgeSphere(new Vector3(this.transform.position.x, top, front));

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

        }
        private void FixedUpdate()
        {
            if(RIGID_BODY.velocity.y<0f)
            {
                RIGID_BODY.velocity -= Vector3.up * GravityMultiplier;
            }

           
        }

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }
    }
}

