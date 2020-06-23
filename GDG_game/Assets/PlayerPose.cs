using System.Collections;
using System.Collections.Generic;
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
                SceneManager.UnloadSceneAsync("Scena_foresta");
                SceneManager.LoadScene("Scena_foresta", LoadSceneMode.Single);
               
                player.GetComponent<CharacterControl>().Die = false;
                

                //SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);


                /* Scene scene = SceneManager.GetActiveScene(); 
                 SceneManager.LoadScene(scene.name);*/
            }

        }
      
    }
}
