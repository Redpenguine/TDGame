using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject uiGameOver;
    public static bool GameIsOver = false;
    
    private void Start()
    {
        uiGameOver.SetActive(false);
    }

    void Update()
    {
        if(GameIsOver)
        return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        uiGameOver.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("GameOver");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

}
