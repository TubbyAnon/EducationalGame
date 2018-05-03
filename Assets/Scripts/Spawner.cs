using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] prefabs;
	public float delay = 2.0f;
	public bool active = true;
	public Vector2 delayRange = new Vector2(1, 2);
    public int xPos;
    public int sW = Screen.width;

	// Use this for initialization
	void Start () {
		ResetDelay ();
		StartCoroutine (EnemyGenerator ());
	}

	IEnumerator EnemyGenerator(){

		yield return new WaitForSeconds (delay);

		if (active) {
			var newTransform = transform;
            System.Random rnd = new System.Random();
            xPos = rnd.Next(0, sW);
            Vector3 newPos = transform.position;
            newPos.x = xPos;
            transform.position = newPos; 

            GameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newPos);
			ResetDelay();
		}

		StartCoroutine (EnemyGenerator ());

	}

	void ResetDelay(){
		delay = Random.Range (delayRange.x, delayRange.y);
	}

}
