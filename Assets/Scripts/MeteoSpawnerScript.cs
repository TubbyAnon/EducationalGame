using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawnerScript : MonoBehaviour {

    public GameObject spawner;
    public float spwanRateInSec = 5f;
	// Use this for initialization
	void Start () {
        Invoke("spawnMeteors", spwanRateInSec);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnMeteors()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        GameObject enemy = (GameObject)Instantiate(spawner);

        enemy.transform.position = new Vector2(Random.Range(min.x + 0.10f , max.x - 0.10f ), max.y);

        nextMeteor();
    }

    void nextMeteor()
    {
        float SecondsIn;

        if(spwanRateInSec > 1f)
        {
            SecondsIn = Random.Range(1f, spwanRateInSec);

        }
        else
        {
            SecondsIn = 1f;
        }

        Invoke("spawnMeteors", SecondsIn);

    }
}
