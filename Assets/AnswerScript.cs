using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour {
    
    string answer;
    // Use this for initialization
    void Start () {

        int test = Random.Range(1, 5);
        if (test == 2)
        {
            answer = GameManagerScript.qh.getCurrentAnswer();
        }
        else
        {
            answer = Random.Range(int.Parse(GameManagerScript.qh.getCurrentAnswer()) - 20, int.Parse(GameManagerScript.qh.getCurrentAnswer()) + 20).ToString();
        }

        var parent = transform.parent;
        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = 5;

        var spriteTransform = parent.transform;
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;
        text.text = answer;
    }

    private void Update()
    {
        
    }
}
