using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
        StreamReader rd = new StreamReader(Application.dataPath + "/Highscore.txt");
        hscore = int.Parse(rd.ReadLine());
        rd.Close();
        HighText.text = hscore.ToString();
    }

	// Update is called once per frame
	void Update () {
        ScoreTxt.text = MeteorScript.score.ToString();
        LivesTxt.text = MovementScript.lives.ToString();
        QuestionTxt.text = GameManagerScript.qh.getCurrentQuestion();
    }
   
}
