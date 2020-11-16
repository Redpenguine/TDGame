using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool paused = false;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                Time.timeScale = 0;
                paused = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                TimeGo();
            }
        }
    }
    public void ExitToMenu()
    {
        TimeGo();
        SceneManager.LoadScene("Menu");
    }
    public void Continue()
    {
        TimeGo();
    }
    public void Exit()
    {
        Application.Quit();
    }

    void TimeGo()
    {
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
    }
}
