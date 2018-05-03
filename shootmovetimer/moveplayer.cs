using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour {

    public GameObject bullet;

    void Update()

    {

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -12, 12);
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))

        {

            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * 1.5f, Quaternion.identity));

            b.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

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
