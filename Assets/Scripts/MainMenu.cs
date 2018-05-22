using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Play_Game()
    {
        SceneManager.LoadScene("FullGame");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

