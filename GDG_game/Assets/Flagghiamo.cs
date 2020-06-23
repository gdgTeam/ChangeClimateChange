using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace roundbeargames_tutorial
{
    public class Flagghiamo : MonoBehaviour
    {
        private static Flagghiamo instance;
        public bool liana;
        public bool spara;
        public bool pianta;
        public bool corazza;
        public CharacterControl control;
        public bool posaPiantina;
        public GameObject salto;
       // public GameObject suggLiana;
       // public GameObject suggSpara;
       
      //  public GameObject suggCorazza;
   

        // Start is called before the first frame update

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }
           
        }
    

        private void Start()
        {
           // control = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        }

        // Update is called once per frame
        public void CheckAbilita()
        {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        if (liana)
            {
               // Destroy(suggLiana);
                control.controllaLiana = true;

            }
            if (pianta)
            {
                Destroy(control.triggerSalto);
                Destroy(control.triggerSx);
                Destroy(control.triggerDx);
                Destroy(control.triggerSpostamento);
                Destroy(control.piantina);
                /*  GameObject.Find("TriggerMuoviASinistra").SetActive(false);
                  GameObject.Find("TriggerMuoviADestra").SetActive(false);
                  GameObject.Find("TriggerSposta").SetActive(false);
                  GameObject.Find("TriggerPianta").SetActive(false);*/

                control.sparaOk = true;
                control.transform.GetChild(3).gameObject.transform.GetComponent<SkinnedMeshRenderer>().enabled = true;
                control.transform.GetChild(2).gameObject.transform.GetComponent<SkinnedMeshRenderer>().enabled = true;
                control.zainoPianta.SetActive(false);
                control.zainoPianta.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                control.RIGID_BODY.isKinematic = false;
                control.checkPickFalse = true;
                control.plant = true;
                control.protectPlant = true;

            }
            
            if(corazza)
            {
                
                control.controllaCorazza = true;
            }
            if (spara)
            {
               
                control.controllaSparo = true;
            }
            if (posaPiantina)
            {
                control.sparaOk = false;
               control.controllaPosaPianta = true;
            }
        }
    }
}
