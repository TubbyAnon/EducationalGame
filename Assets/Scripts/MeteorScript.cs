using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorScript : MonoBehaviour
{
    public static float speed = 2f;
    public Text Score;
    public static int score;
    string answer = "";
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletTag")
        {
            if (gameObject.GetComponentInChildren<TextMesh>().text.ToString().Equals(GameManagerScript.qh.getCurrentAnswer()))
            {
                score += 100;
                
                FindObjectOfType<AudioManagerScript>().Play("PointsEarned");

                if (score > 500)
                {
                    GameManagerScript.qh.loadQuestionSet(2);
                    speed = 4f;
                }
                else if (score > 200)
                {
                    GameManagerScript.qh.loadQuestionSet(2);
                    speed = 3f;
                }
                GameManagerScript.qh.loadQuestion();
            }
            else
            {
                MovementScript.lives--;
                FindObjectOfType<AudioManagerScript>().Play("LifeLost");
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
