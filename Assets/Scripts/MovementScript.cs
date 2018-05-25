using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{

    public GameObject bulletOb;
    public float speed;
    public Vector2 playerpos;
    public Text Lives;
    public static int lives = 3;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    

   


    // Use this for initialization
    void Start()
    {
       
        FindObjectOfType<AudioManagerScript>().Play("Theme");

    }

    // Update is called once per frame
    void Update()
    {
        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }

        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(bulletOb);
            bullet.transform.position = playerpos;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Lives.text = lives.ToString();

        Move(direction);
    }

    void Move(Vector2 direction) //106 x 80 pixels = Spaceship 
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        min.x = min.x + 0.530f;
        max.x = max.x - 0.530f;

        min.y = min.y + 0.400f;
        max.y = max.y - 0.400f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
        playerpos = pos;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MeteorTag")
        {


            lives--;
            FindObjectOfType<AudioManagerScript>().Play("LifeLost");
            startBlinking = true;
            



        }
    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }
}