using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipscript : MonoBehaviour
{
    public GameObject PlayerBulletGo;
    public GameObject BulletPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GameObject bullet = (GameObject)Instantiate(PlayerBulletGo);
            bullet.transform.position = BulletPosition.transform.position;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector3.right * 0.1f);
        }
    }
}

