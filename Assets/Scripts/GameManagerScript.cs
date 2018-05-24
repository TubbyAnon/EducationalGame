using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Text ScoreTxt;
    public Text LivesTxt;
    public Text QuestionTxt;
    public static QuestionHandler qh;
    //public Canvas Pause;
    //public Canvas GameOver;

    int score;
    int lives;
    
    // Use this for initialization
	void Start () {
        qh = new QuestionHandler();
        qh.load("addition");
    }
	
	// Update is called once per frame
	void Update () {
        ScoreTxt.text = score.ToString();
        LivesTxt.text = lives.ToString();
        QuestionTxt.text = "0000000000";

    }
    public void removeLive()
    {
        lives--;
    }
    public void addScore() // for now only 100
    {
        score += 100;
    }
}
