using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorScript : MonoBehaviour {
    public float speed;
    public Text Score;
    int score;
<<<<<<< HEAD
    GameManagerScript gm; 

=======
    int answer;
>>>>>>> 51c73a560049c39b963feebd05d8673d72866752
	// Use this for initialization
	void Start () {
        speed = 2f;
    //    answer = Random.Range(GameManager.qh.getCurrentAnswer() - 20, GameManager.qh.getCurrentAnswer() + 20);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

        Score.text = score.ToString();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.tag == "BulletTag")
        {
<<<<<<< HEAD

            
            score += 100;
=======
            if (answer == GameManager.qh.getCurrentAnswer())
            {
                score += 100;
                GameManager.qh.loadQuestion();
            }
            Destroy(collision.gameObject);
>>>>>>> 51c73a560049c39b963feebd05d8673d72866752
            Destroy(gameObject);
        }
    }
}
