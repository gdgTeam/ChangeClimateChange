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

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        cameraMenu.SetActive(false);
        menuCan.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
