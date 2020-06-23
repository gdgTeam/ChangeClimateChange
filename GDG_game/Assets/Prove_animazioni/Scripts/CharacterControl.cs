﻿using System.Collections;
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
        WalkDownStairs,
        PickDown,
        BalanceWalk,
        Spiderman,
        Die,
        front,
        back,
        Interact,
        Pull,
        PickUpMetallo,
        PickDownMetallo
    }

    public class CharacterControl : MonoBehaviour
    {
        public Vector3 scale= new Vector3();
        public Animator SkinnedMeshAnimator;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Pushing;
        public bool Interact;
        public bool Picking;
        public bool PickingDown;
        public bool PickPlant;
        public bool PickMetal;
        public bool pickedMetal = false;
        public bool LookRight = true;
        public bool LookLeft;
        public bool plant = false;
        public bool checkPick = true;
        public bool checkPickFalse = false;
        public bool Shielding;
        public bool ShieldLast = true;
        public bool sparaOk = true;
        public bool LayerIK;
        public bool interazioneLeva;
        public bool pickMetal;
        public bool protectPlant = false;
        public Vector3 right = new Vector3(0f, 0f, 0f);
        public Vector3 left = new Vector3(0f, 180f, 0f);
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
        public bool WalkDownStair;
        private Rigidbody rigid;
        public StairChecker stairChecker;
        public GameObject Corazza;
        public bool gru;
        public bool Spiderman;
        public bool isSwinging;
        public GameObject spine;
        public Transform targetTransform;
        public LayerMask mouseAimMask;
        private Camera mainCamera;
        public GameObject bulletPrefab;
        public Transform muzzleTransform;
        public Texture2D mouseStandard;
        public Texture2D mouseGrappable;
        public CursorMode cursorMode;
        public Vector2 hotspot = Vector2.zero;
        public bool Pointed = false;
        public bool Ragdoll = false;
        public bool girato;
        public GameObject liana;
        public GameObject Ascensore;
        public int pianoAscensoreOggetto;
        public GameObject pioggia;
        public GameObject triggerPioggiaAcida;
        public GameObject zainetto;
        public GameObject piantina;
        Material[] piantinaMaterials;
        Material[] zainettoMaterial;
        public float add;
        public float posx;
        [SerializeField] private AudioSource soundCorazza;
        public bool saltando;
        public bool spingendo;
        public bool prendendo;
        public bool corazzando;
        public bool posando;
        public bool lianando;
        public bool sparando;
        public bool controllaPosaPianta = false;
        public bool controllaCorazza = false;
        public bool controllaLiana = false;
        public bool controllaSparo = false;
        public GameObject muoviDestra;
        public GameObject triggerSx;
        public GameObject muoviSinistra;
        public GameObject triggerSalto;
        public GameObject triggerDx;
        public GameObject salto;
        public GameObject triggerSpostamento;
        public GameObject spingi;
        public GameObject triggerCorazza;
        public GameObject triggerPianta;
        public GameObject triggerPosaPianta;
        public GameObject triggerLiana;
        public GameObject triggerAscensore;
        public GameObject triggerGermogli;
        public GameObject prendiPianta;
        public GameObject suggCorazza;
        public GameObject suggPosaPianta;
        public GameObject suggLiana;
        public GameObject suggAscensore;
        public GameObject suggChiamataAscensore;
        public GameObject suggGermogli;
        public GameObject audioManager;
        public List<GameObject> OggettiInter = new List<GameObject>();
        public Flagghiamo checkpoint;
        public GameObject zainoPianta;
        public bool Die;
       

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
            piantina = this.transform.GetChild(2).gameObject;
            zainetto = this.transform.GetChild(3).gameObject;
            posx = this.transform.position.x;
            scale = this.transform.localScale;
            mainCamera = Camera.main;
            Cursor.SetCursor(mouseStandard, hotspot, cursorMode);
            soundCorazza = GetComponent<AudioSource>();
            pianoAscensoreOggetto = 2;
            checkpoint = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Flagghiamo>();
            FindObjectOfType<AudioManager>().Play("audio_foresta");
           // TurnOFFRagdoll();
        }

        private void Update()
        {

            if (corazzando == true && suggCorazza.active)
            {
                Destroy(triggerCorazza);
                suggCorazza.active = false;
            }

            if (spingendo == true && spingi.active)
            {
                Destroy(triggerSpostamento);
                spingi.active = false;
                triggerCorazza.active = true;
            }

            if (prendendo == true && prendiPianta.active)
            {
                Destroy(triggerPianta);
                prendiPianta.active = false;
                triggerSpostamento.active = true;
            }

            if (sparando == true && suggGermogli.active)
            {
                suggGermogli.active = false;
                Destroy(triggerGermogli);
            }

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
            if (stairChecker.StairVal == true )
            {
                if( stairChecker.lastStair.VersoAvanti == true && girato== false)
                {
                    WalkDownStair = false;
                    WalkUpStair = true;
                }
               

                else if (stairChecker.lastStair.VersoAvanti == true && girato== true)
                {
                    WalkUpStair = false;
                    WalkDownStair = true;
                }
                else if (stairChecker.lastStair.VersoAvanti == false && girato == false)
                {
                    WalkUpStair = false;
                    WalkDownStair = true;
                }
                else if (stairChecker.lastStair.VersoAvanti == false && girato == true)
                {
                    WalkUpStair = true;
                    WalkDownStair = false;
                }

            }
            if (stairChecker.StairVal == false )
            {
                
                WalkDownStair = false;
                WalkUpStair = false;
                SkinnedMeshAnimator.SetBool(TransitionParameter.WalkDownStairs.ToString(), false);
                SkinnedMeshAnimator.SetBool(TransitionParameter.WalkUpStairs.ToString(), false);

            }

            if (Shielding && protectShield)
            {
                protectShield = false;
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = true;
                Corazza.GetComponent<AudioSource>().Play();
                //soundCorazza.Play();
            }
            if (!Shielding && !protectShield)
            {
                protectShield = true;
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = false;
            }
            if (ShieldLast)
            {
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = false;
            }
            if (!ShieldLast)
            {
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = true;
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
           if(Ragdoll == true)
            {
                TurnOnRagdoll();
            }
            if (controllaCorazza)
            {
                checkpoint.corazza = true;
            }
            if (controllaLiana)
            {
                checkpoint.liana = true;
            }
            if(controllaSparo)
            {
                checkpoint.spara = true;
            }
            if (plant)
            {
                
                checkpoint.pianta = true;
            }
            if (controllaPosaPianta)
            {

                checkpoint.posaPiantina = true;
            }
            /*  if (Ragdoll == false)
              {
                 TurnOFFRagdoll();
              }*/



            //Aim control
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction*10f);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimMask))
            {
                if (!girato && hit.point.z > this.transform.position.z)
                {
                    targetTransform.position = new Vector3(this.transform.position.x - 0.5f, hit.point.y, hit.point.z);
                }
                else if(girato && hit.point.z < this.transform.position.z ){
                    targetTransform.position = new Vector3(this.transform.position.x - 0.5f, hit.point.y, hit.point.z);
                }
                else
                {
                    targetTransform.position = new Vector3(this.transform.position.x - 0.5f, hit.point.y, this.transform.position.z);
                }

                if (hit.collider.gameObject.tag == "Grappable" && isSwinging == false)
                {
                    Pointed = true;
                    //cambia colore dell'oggetto
                    Cursor.SetCursor(mouseGrappable, hotspot, cursorMode);
                    GetComponent<DistanceJoint3D>().ConnectedRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>().transform;
                }
                else
                {
                    Pointed = false;
                    Cursor.SetCursor(mouseStandard, hotspot, cursorMode);
                    //GetComponent<DistanceJoint3D>().ConnectedRigidbody = null;
                }
            }


            if (controllaSparo && LayerIK)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    fire();
                }
            }

        }

        private void Awake()
        {
            SetRagdollParts();
            SetCollidersSpheres();
            /*if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }*/

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

           
            /* if(col.gameObject.tag == "Fire")
             {
                Debug.Log("ColliderFire");
                CheckCorazza();
             }*/
             
             if (col.gameObject.name == "TriggerPioggia")
             {
                Debug.Log("Pioggia");
                FindObjectOfType<AudioManager>().Play("audio_pioggia");
                pioggia.active = true;
                triggerPioggiaAcida.active = true;
             }

            if (col.gameObject.name == "TriggerFinePioggia" && sparaOk && pickedMetal)
            {
                FindObjectOfType<AudioManager>().sounds[2].loop = false;
                pioggia.active = false;
                triggerPioggiaAcida.active = false;
            }

        }

        private void OnTriggerStay(Collider col)
        {
           
           /* if (col.gameObject.tag == "Fire")
            {
                Debug.Log("StayFire");
                CheckCorazza();

            }*/

            

            if (col.gameObject.name == "TriggerPioggiaAcida" && sparaOk && !pickedMetal)
            {
                Debug.Log("StayPioggia");
                add = add + 0.01f;
                piantinaMaterials = piantina.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                zainettoMaterial = zainetto.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                piantinaMaterials[0].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[1].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[2].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[3].SetFloat("Vector1_ACBAB4A6", add);
                zainettoMaterial[0].SetFloat("Vector1_9ACB71BD", add);
                if (add >= 1) //temporaneo
                {
                    OnExit();
                }
            }

            if(col.gameObject.name == "TriggerAcqua" && sparaOk)
            {
                add = add + 0.005f;
                piantinaMaterials = piantina.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                zainettoMaterial = zainetto.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                piantinaMaterials[0].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[1].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[2].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[3].SetFloat("Vector1_ACBAB4A6", add);
                StartCoroutine(DieAcquaLago());
               
                //zainettoMaterial[0].SetFloat("Vector1_9ACB71BD", add);
                if (add >= 1) //temporaneo
                {
                    OnExit();
                }
            }
           

            if(col.gameObject.name == "TriggerMuoviaDestra")
            {
                muoviDestra.active = true;
                if (MoveRight == true)
                {
                    Destroy(col.gameObject);
                    muoviDestra.active = false;
                    triggerSx.active = true;
                }

            }

            if (col.gameObject == triggerSx)
            {
                muoviSinistra.active = true;
                if(MoveLeft == true)
                {
                    Destroy(col.gameObject);
                    muoviSinistra.active = false;
                    triggerSalto.active = true;
                }
            }

            if(col.gameObject == triggerSalto)
            {
                salto.active = true;
                if(saltando == true)
                {
                    Destroy(col.gameObject);
                    salto.active = false;
                    triggerPianta.active = true;
                }
            }

            if(col.gameObject == triggerPianta)
            {
                prendiPianta.active = true;
                if(prendendo == true)
                {
                    Destroy(col.gameObject);
                    prendiPianta.active = false;
                    triggerSpostamento.active = true;
                }
            }

            if(col.gameObject == triggerSpostamento)
            {
                spingi.active = true;
                if (spingendo == true)
                {
                    Destroy(col.gameObject);
                    spingi.active = false;
                    triggerCorazza.active = true;
                }
            }

            if(col.gameObject == triggerCorazza)
            {
                controllaCorazza = true;
                suggCorazza.active = true;
                if(corazzando == true)
                {
                    Destroy(col.gameObject);
                    suggCorazza.active = false;
                }
            }

            if(col.gameObject == triggerPosaPianta)
            {
                controllaPosaPianta = true;
                suggPosaPianta.active = true;
                if (posando == true)
                {
                    Destroy(col.gameObject);
                    suggPosaPianta.active = false;
                }
            }
            
            if (col.gameObject == triggerLiana)
            {
                controllaLiana = true;
                suggLiana.active = true;
                if(lianando == true)
                {
                    Destroy(col.gameObject);
                    suggLiana.active = false;
                }
            }

            if(col.gameObject == triggerAscensore)
            {
                suggAscensore.active = true;
            }
            else
            {
                suggAscensore.active = false;
            }

            if(col.gameObject.tag == "ChiamataAscensore")
            {
                suggChiamataAscensore.active = true;
            }
            else
            {
                suggChiamataAscensore.active = false;
            }

            if(col.gameObject == triggerGermogli)
            {
                suggGermogli.active = true;
                controllaSparo = true;
                if (sparando == true)
                {
                    suggGermogli.active = false;
                    Destroy(triggerGermogli);
                }
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

                c.enabled = true;
                 c.isTrigger = false;
                 c.attachedRigidbody.velocity = Vector3.zero;
             }
         }
        private IEnumerator DieAcquaLago()
        {
            Debug.Log("muoripiantina");
            yield return new WaitForSeconds(1f);
            Die = true;
        }
        public void TurnOFFRagdoll()
        {
           /* foreach(Transform child in transform)
            {
                if (child.GetComponent<Collider>() != null)
                {
                    child.GetComponent<Collider>().enabled = false;
                }
                if (child.GetComponent<Rigidbody>() != null)
                {
                    Destroy(child.GetComponent<Rigidbody>());
                }
                if (child.GetComponent<CharacterJoint>() != null)
                {
                    Destroy(child.GetComponent<CharacterJoint>());
                }
               

            }*/
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
            Corazza.transform.rotation = Quaternion.Euler(0.0f, 0.0f, this.gameObject.transform.rotation.z * -1.0f * Time.deltaTime);

            if (RIGID_BODY.velocity.y<0f)
            {
                RIGID_BODY.velocity -= Vector3.up * GravityMultiplier;
            }

           
        }

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }

        private void OnAnimatorIK()

        {
            if (LayerIK)
            {
                //mira al target con IK
                SkinnedMeshAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                SkinnedMeshAnimator.SetIKPosition(AvatarIKGoal.RightHand, targetTransform.position);

                //look at target
                SkinnedMeshAnimator.SetLookAtWeight(1);
                SkinnedMeshAnimator.SetLookAtPosition(targetTransform.position);
                /*this.GetComponent<Animator>().SetLayerWeight(0, 0);
                this.GetComponent<Animator>().SetLayerWeight(2, 1);*/
            }   

        }

        private void fire()
        {
            if (sparaOk == true)
            {
                var go = Instantiate(bulletPrefab);
                go.transform.position = muzzleTransform.position;
                var bullet = go.GetComponent<Bullet>();
                //bullet.fire(go.transform.position, muzzleTransform.eulerAngles, gameObject.layer);
                bullet.fire_prova(go.transform.position, targetTransform.position);
            }
        }

        public void GestisciIK()
        {

        }

        public void OnExit()
        {
            add = 0;
        }

        public AudioManager GetAudioManager()
        {
            AudioManager am = audioManager.GetComponent<AudioManager>();
            return am;
        }
    }
}