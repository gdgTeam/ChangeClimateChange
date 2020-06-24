using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace roundbeargames_tutorial
{
    public class PlayerPose : MonoBehaviour
    {
        private GameMaster gm;
        private Flagghiamo flag;
        private GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            flag = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Flagghiamo>();
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            transform.position = gm.lastCheckPointPose;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
       

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
 


        }


        // Update is called once per frame
        void Update()
        {
            if(player.GetComponent<CharacterControl>().Die==true)
            {
                transform.position = gm.lastCheckPointPose;
                // SceneManager.LoadScene("Animazioni", LoadSceneMode.Single);
                Debug.Log("jb");
                foreach(GameObject o in player.GetComponent<CharacterControl>().OggettiInter)
                {
                    Destroy(o);
                }
                // SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Animazioni"));
                DontDestroyOnLoad(player);
                
                SceneManager.UnloadSceneAsync("Scena_foresta");
                SceneManager.LoadScene("Scena_foresta", LoadSceneMode.Single);
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
                CharacterControl control = player.GetComponent<CharacterControl>();
                if (!control.protectPlant)
                {
                    control.zainoPianta.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 0.2f);
                }
                /*control.zainoPianta.transform.parent = GameObject.Find("mixamorig: RightHand").transform;
                control.zainoPianta.transform.localPosition = new Vector3(0.631783f, 1.027834f, 0.3071281f);
                
                control.zainoPianta.transform.localRotation = Quaternion.Euler(-142.972f, -67.46899f, 43.646f);
               
                control.zainoPianta.transform.localScale = new Vector3(77.20261f, 77.20261f, 77.20261f);
               */
                
                player.GetComponent<CharacterControl>().Die = false;
                

                //SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);


                /* Scene scene = SceneManager.GetActiveScene(); 
                 SceneManager.LoadScene(scene.name);*/
            }

        }
      
    }
}
