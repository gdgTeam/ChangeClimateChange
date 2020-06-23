using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPose : MonoBehaviour
{
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPose;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            SceneManager.LoadScene("Animazioni", LoadSceneMode.Single);
            SceneManager.LoadScene("Scena_foresta", LoadSceneMode.Additive);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);

            /* Scene scene = SceneManager.GetActiveScene(); 
             SceneManager.LoadScene(scene.name);*/
        }
    }
}
