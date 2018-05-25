using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour {
    string question;
    public Text txt;
	// Use this for initialization
	void Start () {
        question = GameManagerScript.qh.getCurrentQuestion();
        var parent = transform.parent;
        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;

        var spriteTransform = parent.transform;
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;


        txt = gameObject.GetComponent<Text>();
        txt.text = GameManagerScript.qh.getCurrentQuestion();
        Debug.Log(question + " QUestion");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
