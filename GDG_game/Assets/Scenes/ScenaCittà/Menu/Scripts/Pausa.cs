using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Threading;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject options;
    public GameObject menuIniziale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (menuIniziale.active == false)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;       
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        options.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Opzioni()
    {
        options.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
}
