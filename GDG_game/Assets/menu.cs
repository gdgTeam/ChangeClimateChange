using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource click;
    public GameObject cameraMenu;
    public GameObject menuCan;
    public GameObject player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayGame()
    {

        //player.GetComponent<Animator>().SetBool("Die", true);
        SceneManager.LoadScene("Scena_foresta", LoadSceneMode.Single);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Animazioni", LoadSceneMode.Additive);
        cameraMenu.SetActive(false);
        menuCan.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
