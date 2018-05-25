using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Text ScoreTxt;
    public Text LivesTxt;
    public Text QuestionTxt;
    public Text HighText;
    public static QuestionHandler qh;
    public static int hscore;
    //public Canvas Pause;
    //public Canvas GameOver;

    int score;
    int lives;
    
    // Use this for initialization
	void Start () {
        qh = new QuestionHandler();
        qh.load("easy");
        hscore = int.Parse(new System.IO.StreamReader(Application.dataPath + "/Highscore.txt").ReadLine());
        HighText.text = hscore.ToString();
    }

	// Update is called once per frame
	void Update () {
        ScoreTxt.text = MeteorScript.score.ToString();
        LivesTxt.text = MovementScript.lives.ToString();
        QuestionTxt.text = GameManagerScript.qh.getCurrentQuestion();
    }
   
}
