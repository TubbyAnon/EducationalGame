using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class PauseScript : MonoBehaviour {

    public static bool IsPaused = false;
    public static bool GameOver = false; //to be used from outside. when true the game is over.
    public static bool FirstTime = true;
    private static bool written = false;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject GameOverScreen;
    public GameObject IntroMenu;

    private void Start()
    {
        
        if (FirstTime == true)
        {
            Intro(true);
        }
        
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

        if(MeteorScript.score > GameManagerScript.hscore && written == false)
        {
            StreamWriter sw = new StreamWriter(Application.dataPath + "/Highscore.txt");
            sw.WriteLine(MeteorScript.score);
            sw.Close();
            written = true;
        }
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        GameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        GameOver = false;
        IntroMenu.SetActive(false);
        MeteorScript.score = 0;
        MeteorScript.speed = 2f;
        MovementScript.lives = 3;
        written = false;
        Menu();
    }

    public void DisableIntro()
    {

        IntroMenu.SetActive(false);
        Resume();
    }

    public void Intro(bool op)
    {
        if (op)
        {
            IntroMenu.SetActive(true);
            Time.timeScale = 0f;
            FirstTime = false;
        }
        else
        {
            IntroMenu.SetActive(false);
            Time.timeScale = 1f;
            FirstTime = false;

        }
        


    }



}
