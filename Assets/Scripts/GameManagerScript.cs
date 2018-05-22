using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Text ScoreTxt;
    public Text LivesTxt;

    public GameObject PausePanel;
    public GameObject GameOver;

    //public Canvas Pause;
    //public Canvas GameOver;

    int score = 0;
    int lives;
    bool isPaused  = false;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P) && isPaused.Equals(false))
        {
            PauseGame();

        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused.Equals(true))
        {
            ResumeGame();
        }

        if (LivesTxt.text.Equals("0"))
        {
            
            gameOver();

        }

        ScoreTxt.text = score.ToString();

	}


    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        PausePanel.SetActive(true);

    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    void gameOver()
    {
        PauseGame();
        isPaused = false;
        GameOver.SetActive(true);
    }

    public void addScore()
    {
        score += 100;

    }

   

}
