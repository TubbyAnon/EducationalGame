using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorScript : MonoBehaviour {
    public float speed;
    public Text Score;
    int score;
    string answer = "";
	// Use this for initialization
	void Start () {
        speed = 2f;
        if (Random.Range(1, 5) == 4)
        {
            answer = GameManagerScript.qh.getCurrentAnswer();
        }
        else
        {
            answer = Random.Range(int.Parse(GameManagerScript.qh.getCurrentAnswer()) - 20, int.Parse(GameManagerScript.qh.getCurrentAnswer()) + 20).ToString();

        }
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
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletTag")
        {
            if (answer == GameManagerScript.qh.getCurrentAnswer())
            {
                score += 100;
                GameManagerScript.qh.loadQuestion();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
