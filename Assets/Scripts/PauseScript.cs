using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public static bool IsPaused = false;
    public static bool GameOver = false; //to be used from outside. when true the game is over.

    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject GameOverScreen;
    public GameObject IntroMenu;

    private void Start()
    {
        IntroMenu.SetActive(true);
        Pause();
    }


    void Update () {

        if (MovementScript.lives == 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
       

	}


    public void Resume()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }


    public void Menu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
        

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void EndGame()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        GameOver = false;

    }

    public void DisableIntro()
    {

        IntroMenu.SetActive(false);
        Resume();
    }





}
