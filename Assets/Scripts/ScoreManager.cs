using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static int score;    // The player's score
	public Text text;          // Reference to the Text component

	void Start(){
		text.text = "";
	}
	void Awake ()
	{
		text = GetComponent <Text> ();  // Set up the reference
		score = 0;  // Reseting the score
	}
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value
		text.text = "Score: " + score;
	}
}